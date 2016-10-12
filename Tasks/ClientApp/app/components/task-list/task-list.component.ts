/// <reference path="task.ts" />
import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable'

import { Task } from './task';
import { TaskService } from '../../services/task.service';

@Component({
    selector: 'task-list',
    template: require('./task-list.component.html')

})

export class TaskListComponent implements OnInit {
    errorMessage: string;
    tasks = new Array<Task>();
    
  


    constructor(private taskService: TaskService, ) {
        
    }

    ngOnInit(): void {

        this.tasks = this.taskService.getTasks();
    }


    

    //getTasks() {
    //    this.taskService.getTasks()
    //        tasks => this.tasks = tasks
    //    alert(this.tasks.length);



    //    this.taskService.getTasks()
    //        .subscribe(
    //        tasks => this.tasks = tasks,
    //        error => this.errorMessage = <any>error);

        //for (var index = 0; index < this.tasks.length; index++)
        //alert(this.tasks[index].title);
        
        
    //}

    //getTasks(): void {
    //    this.taskService.getTasks()
    //        .subscribe(
    //        result => this.tasks = result,
    //        error => this.errorMessage = <any>error);

    //    }
    


    //completeTask(task: Task) {
    //    if (task.completed !== true) {
    //        task.completed = true;
    //        task.buttonText = "Not Complete";
    //    }

    //    else {
    //        task.completed = false;
    //        task.buttonText = "Complete";
    //    }
    //    this.taskService.updateTask(task)
    //        .then(task => {
    //            this.task
    //        });
    //}

}