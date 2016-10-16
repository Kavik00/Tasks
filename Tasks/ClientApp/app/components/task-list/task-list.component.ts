﻿
import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable'

import { TaskItem } from './taskItem';
import { TaskService } from '../../services/task.service';

@Component({
    selector: 'task-list',
    template: require('./task-list.component.html'),
    styles: [require('./task-list.component.css')]
    

})

export class TaskListComponent implements OnInit {
    private errorMessage: string;
    public tasks;
    taskItem: TaskItem;
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private options = new RequestOptions({ headers: this.headers });

    constructor(private _http: Http) {
        this.taskItem = new TaskItem();
            }

    ngOnInit(): void {
        this.getTasks()
                
    }

    getTasks() {
        this.serviceGetTasks()
            .subscribe(
            resp => this.tasks = resp,
            error => this.errorMessage = <any>error);

    }
    serviceGetTasks(): Observable <TaskItem[]> {
   
        return this._http.get('/api/TasksData/GetTasks')
            .map((response: Response) => response.json());        
    }
 

    addTask() {
        this.taskItem.title.trim();
        if (!this.taskItem.title) { return; }
        this.serviceCreate(this.taskItem)
            .subscribe(
            resp => this.tasks.push(resp));          
  
    }

    serviceCreate(taskItem: TaskItem): Observable<TaskItem> {

        let body = JSON.stringify(taskItem);

        alert("the service got called. Create " + taskItem.title)

        return this._http.post('/api/TasksData/CreateTask', body, this.options)
            .map(res => res.json());
 
    }
    
    
    completeTask(task: TaskItem) {
        if (task.completed !== true) {
            task.completed = true;
            task.buttonText = "Not Complete";
        }

        else {
            task.completed = false;
            task.buttonText = "Complete";
        }

            
    }

    deleteTask(task: TaskItem): void {
        this.tasks = this.tasks.filter(h => h !== task);
        this._http.delete('[/api/TasksData/DeleteTask/${task}', { headers: this.headers }).toPromise().then(() => null);
        
    }


    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}