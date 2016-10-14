import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { TaskItem } from '../components/task-list/taskItem';

@Injectable()
export class TaskService {

    private tasksUrl = '/api/TasksData/GetTasks'; //URL to web api
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private tasks = new Array<TaskItem>();

    constructor(private _http: Http) {}

    getTasks() {
        this._http.get('/api/TasksData/GetTasks').subscribe(result => {
            this.tasks = result.json();
        });
        return this.tasks;   

    }

    //getTasks (): Observable <Task[]> {

    //    return this._http.get(this.tasksUrl)
    //        //.map(response => response.json().data as Task[])
    //        .map (this.extractData)
    //        .catch(this.handleError);
            
    //}


    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }


    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);

    }

}