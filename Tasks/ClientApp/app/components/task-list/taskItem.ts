

export class TaskItem {
    id: number;
    title: string;
    completed: boolean;
    createdDate: Date;
    updatedDate: Date;
    notes: string;
    buttonText: string;

    constructor() {
        this.title = "";
        this.completed = false;
        this.createdDate = this.getToday();
        this.updatedDate = this.getToday();
        this.notes = "";
        this.buttonText = "Complete";
    }

    getToday(): Date {
        let currentDate = new Date();
        let datetime = "Last Sync: " + currentDate.getDate() + "/"
            + (currentDate.getMonth() + 1) + "/"
            + currentDate.getFullYear() + " @ "
            + currentDate.getHours() + ":"
            + currentDate.getMinutes() + ":"
            + currentDate.getSeconds();
        return currentDate;
    }

}