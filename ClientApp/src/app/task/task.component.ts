import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { TaskService } from '../services/task.service';
import { Task } from '../models/task';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  task$: Observable<Task>;
  Id: number;

  constructor(private taskService: TaskService, private avRoute: ActivatedRoute) { 
    const idParam="id";
    if(this.avRoute.snapshot.params[idParam]){
      this.Id = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadTask();
  }

  loadTask(){
    this.task$ = this.taskService.getTask(this.Id);
  }

}
