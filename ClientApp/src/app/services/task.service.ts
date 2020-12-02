import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Task } from '../models/task';
import { environment } from 'src/environments/environment'

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  }
  constructor(private http: HttpClient) { 
    this.myAppUrl=environment.appUrl;
    this.myApiUrl='api/Tasks'
  }
  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.myAppUrl + this.myApiUrl + "/List")
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getTask(Id: number): Observable<Task> {
      return this.http.get<Task>(this.myAppUrl + this.myApiUrl + "/" + Id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveTask(task): Observable<Task> {
      return this.http.post<Task>(this.myAppUrl + this.myApiUrl, task, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateTask(task): Observable<Task> {
      return this.http.put<Task>(this.myAppUrl + this.myApiUrl, task, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteTask(Id: number): Observable<Task> {
      return this.http.delete<Task>(this.myAppUrl + this.myApiUrl + "/" +Id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
