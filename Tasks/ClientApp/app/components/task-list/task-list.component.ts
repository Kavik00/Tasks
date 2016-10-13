/// <reference path="task.ts" />
import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable'

import { Task } from './task';
import { TaskService } from '../../services/task.service';

@Component({
    selector: 'task-list',
    template: require('./task-list.component.html'),
    styles: [require('./task-list.component.css')]
    

})

export class TaskListComponent implements OnInit {
    private errorMessage: string;
    public tasks: Task[];
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private _http: Http) { }

    ngOnInit(): void {
        this.getTasks();
        
    }

    getTasks() {

        this._http.get('/api/TasksData/GetTasks').subscribe(result => {
            this.tasks = result.json();
        });
    }
    
    
    completeTask(task: Task) {
        if (task.completed !== true) {
            task.completed = true;
            task.buttonText = "Not Complete";
        }

        else {
            task.completed = false;
            task.buttonText = "Complete";
        }

            
    }

    deleteTask(task: Task): void {
        this.tasks = this.tasks.filter(h => h !== task);
        this._http.delete('[/api/TasksData/DeleteTask/${task}', { headers: this.headers }).toPromise().then(() => null);
        

    }

}