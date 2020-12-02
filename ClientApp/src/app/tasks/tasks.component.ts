import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskService } from '../services/task.service';
import { Task } from '../models/task';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  tasks$: Observable<Task[]>;

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.tasks$ = this.taskService.getTasks();
  }

  delete(taskId) {
    const ans = confirm('Do you want to delete task with id: ' + taskId);
    if (ans) {
      this.taskService.deleteTask(taskId).subscribe((data) => {
        this.loadTasks();
      });
    }
  }

}
