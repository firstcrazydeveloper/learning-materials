import { Component, HostListener, OnInit } from '@angular/core';
import { BasicCalculator } from './basic-calculator';
import { Operators } from './arithmetic/operators';

@Component({
    selector: 'ng-calculator',
    templateUrl: './calculator.component.html',
    styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
    private showResult = false;
    private calculator: BasicCalculator;

    public constructor() {}

    public get input(): string {
        return this.calculator.input;
    }

    public get formattedInputs(): string {
        return this.calculator.formattedInputs;
    }

    public evaluateInputs(): void {
        if (this.calculator.isValidEvaluate) {
            this.calculator.evaluateInputs();
        }

        this.showResult = true;
    }

    public executeOperator(operator: any): void {
        this.calculator.executeOperator(operator, this.showResult);
        this.showResult = false;
    }

    public reset(): void {
        this.calculator.reset();
        this.showResult = false;
    }

    public insertInput(input: string): void {
        this.calculator.setInput(input, this.showResult);
        this.showResult = false;
    }

    public delete(): void {
        this.calculator.deleteDigit();
    }

    public undo(): void {
        this.calculator.undoLastStep();
    }

    public toogleInput(): void {}

    public ngOnInit(): void {
        this.calculator = new BasicCalculator();
    }

    // KEYBOARD SUPPORT
    @HostListener('window:keydown', ['$event'])
    onKeyDown(event: KeyboardEvent) {
        const key = event.key.toLowerCase();

        event.preventDefault();

        if (key === 'c' || key === 'backspace') {
            this.reset();
        } else if (key === ',' || key === '.') {
            this.insertInput('.');
        } else if (!isNaN(parseInt(key))) {
            this.insertInput(key);
        } else if (key === 'enter') {
            this.evaluateInputs();
        } else if (Operators.isOperator(key)) {
            this.executeOperator(key);
        }
    }
}
