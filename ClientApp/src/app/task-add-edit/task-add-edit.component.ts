import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TaskService } from '../services/task.service';
import { Task } from '../models/task';
import {pluck, switchMap, take, takeUntil} from 'rxjs/operators';
import {Observable, Subject} from 'rxjs';

@Component({
  selector: 'app-task-add-edit',
  templateUrl: './task-add-edit.component.html',
  styleUrls: ['./task-add-edit.component.css']
})
export class TaskAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formTitle: string;
  formDescription: string;
  formEndDateTime: string;

  formCompleted: boolean;
  Id: number;
  errorMessage: any;
  existingTask: Task;
  taskId$ = this.activatedRoute.params.pipe(pluck('id'));
  destroy$ = new Subject();

  constructor(private taskService: TaskService,private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formTitle = 'title';
    this.formDescription = 'description';
    this.formEndDateTime = 'endDateTime';


    this.formCompleted = false;
    if (this.avRoute.snapshot.params[idParam]) {
      this.Id = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        id: 0,
        title: ['', [Validators.required]],
        description: ['', [Validators.required]],
        endDateTime: ['', [Validators.required]],
        completed: []
      }
    )
  }

  ngOnInit() {
    if(this.Id>0){
      this.actionType = 'Edit';
      this.taskId$.pipe(switchMap(taskId =>{
        return this.taskService.getTask(taskId);
      }), takeUntil(this.destroy$)).subscribe(task => {
        this.form.get('title').patchValue(task.title);
        this.form.get('description').patchValue(task.description);
        this.form.get('endDateTime').patchValue(task.endDateTime);
        this.form.get('completed').patchValue(task.completed);
      });
    }
  }


  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let task: Task = {
        endDateTime: this.form.get(this.formEndDateTime).value,
        completed: false,
        title: this.form.get(this.formTitle).value,
        description: this.form.get(this.formDescription).value
      };

      this.taskService.saveTask(task)
        .subscribe((data) => {
          this.router.navigate(['/']);
        });
    }

    if (this.actionType === 'Edit') {
      let task: Task = {
        id: +this.Id,
        endDateTime: this.form.get('endDateTime').value,
        completed: this.form.get('completed').value,
        title: this.form.get(this.formTitle).value,
        description: this.form.get(this.formDescription).value
      };
      this.taskService.updateTask(task)
        .subscribe((task) => {
          this.router.navigate(['/']);
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get title() { return this.form.get(this.formTitle); }
  get body() { return this.form.get(this.formDescription); }

}
