import { Operators } from './arithmetic/operators';
import Big from 'big.js';
import { ArithmeticExpressionManager } from './arithmetic/arithmetic-expression-manager';
import { ErrorMessage } from './error-message';

export class BasicCalculator {
    private errorMessage: ErrorMessage;
    private states: Array<BasicCalculator> = [];
    private inputs: string[] = [];
    private isEvaluated = false;
    private format = (input: string): string => {
        if (Operators.isOperator(input)) {
            return input;
        } else {
            return input.replace('.', ',');
        }
    };

    public constructor() {
        this.errorMessage = new ErrorMessage();
    }

    private get lastInput(): string {
        return this.inputs[this.inputs.length - 1];
    }

    private get beforeLastInput(): string {
        return this.inputs[this.inputs.length - 2];
    }

    private applyOperatorPrecedenceRules(inputs: string[]): string[] {
        const ops = { '+': 1, '-': 1, '*': 2, '/': 2 };
        const peek = arr => arr[arr.length - 1];
        const stack = [];

        return inputs
            .reduce((output, input) => {
                if (!Operators.isOperator(input)) {
                    output.push(input);
                } else {
                    if (input in ops) {
                        while (peek(stack) && ops[input] <= ops[peek(stack)]) {
                            output.push(stack.pop());
                        }

                        stack.push(input);
                    }

                    if (input === '(') {
                        stack.push(input);
                    }

                    if (input === ')') {
                        while (stack.length > 0 && peek(stack) !== '(') {
                            output.push(stack.pop());
                        }
                        stack.pop();
                    }
                }

                return output;
            }, [])
            .concat(stack.reverse());
    }

    private processCalculation(inputs: string[]): Big {
        const stack: Big[] = [];

        if (inputs.length > 0) {
            inputs.forEach(input => {
                if (!Operators.isOperator(input)) {
                    stack.push(Big(input));
                } else if (stack.length >= 2) {
                    const val2 = stack.pop();
                    const val1 = stack.pop();
                    const numericOperand = ArithmeticExpressionManager.getNumericOperand(input);
                    stack.push(numericOperand.doAction(val1, val2));
                }
            });

            return stack.pop().round(10);
        }
    }

    private setStates(): void {
        this.states.push(JSON.parse(JSON.stringify(this)));
    }    

    public get isValidEvaluate(): boolean {
        return this.inputs.length >= 2;
    }

    public get formattedInputs(): string {
        return this.inputs.map(this.format).join(' ').replace(/\*/g, 'x') || '0';
    }    

    public get input(): string {
        try {
            if (this.inputs.length > 0) {
                return this.format(this.processCalculation(this.applyOperatorPrecedenceRules(this.inputs)).toString());
            }
            return '';
        } catch (e) {
            return this.errorMessage.getErrorMEssage(e.message);
        }
    }

    public evaluateInputs(): void {
        if (!this.isEvaluated) {
            this.isEvaluated = true;
            this.setStates();
        }
    }

    public setInput(input: string, isFinalResult: boolean = false): void {
        this.isEvaluated = false;
        const lastInput = this.lastInput;
        const doubleMin = lastInput === '-' && Operators.isOperator(this.beforeLastInput);
        if (lastInput === undefined || (Operators.isOperator(lastInput) && !doubleMin)) {
            if (input === '.') {
                input = '0' + input;
            }
            this.inputs.push(input);
        } else if (isFinalResult) {
            this.inputs = [input];
        } else {
            this.inputs[this.inputs.length - 1] = lastInput + input;
        }
    }

    public executeOperator(operator: any, isFinal: boolean = false): void {
        this.isEvaluated = false;
        if (isFinal) {
            this.inputs = [this.processCalculation(this.applyOperatorPrecedenceRules(this.inputs)).toString()];
        }

        if (!this.lastInput && operator !== '(') {
            this.inputs.push('0');
        }

        this.inputs.push(operator);
    }

    public reset(): void {
        this.inputs = [];
        this.states = [];
    }

    public undoLastStep(): void {
        if (this.inputs.length > 1) {
            this.inputs.pop();
            this.inputs.pop();
        } else {
            if (this.states.length > 0) {
                const lastStates = this.states.pop();
                this.inputs = lastStates.inputs;
            }
        }
    }

    public deleteDigit(): void {
        if (!Operators.isOperator(this.lastInput)) {
            this.inputs[this.inputs.length - 1] = this.lastInput.substring(0, this.lastInput.length - 1);
        }
    }
}
