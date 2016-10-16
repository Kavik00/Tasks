import { Component } from '@angular/core';

@Component({
    selector: 'counter',
    template: require('./counter.component.html'),
    styles: [require('./counter.component.css')]
})
export class CounterComponent {
    public currentCount = 0;

    private display: string = "";
    private memory: string = "0";
    private mp: string = "";
 
    public incrementCounter() {
        this.currentCount++;
    }

    public v(val: any) {
        this.display += val;
    }

    public e() {
        this.display = eval(this.display);
    }

    public c() {
        this.display = "";
    }

    public memPlus() {
        try {

            this.display = eval(this.display + " + " + this.memory);
            this.memory = this.display
            
        }

        catch (Error) {
            console.log(Error);
        }
   
    }

    public memMinus() {
        try {

            this.display = eval(this.display + " - " + this.memory);
            this.memory = this.display
            
        }

        catch (Error) {
            console.log(Error);
        }
    }

    private memRecall() {
        if (this.display === this.memory) {
            this.memory = "0"
            this.display="";
        }
        else this.display = this.memory;
    }
}
