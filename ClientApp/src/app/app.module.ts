import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TasksComponent } from './tasks/tasks.component';
import { TaskComponent } from './task/task.component';
import { TaskAddEditComponent } from './task-add-edit/task-add-edit.component';
import { TaskService } from './services/task.service';


@NgModule({
  declarations: [
    AppComponent,
    TasksComponent,
    TaskComponent,
    TaskAddEditComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    TaskService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
