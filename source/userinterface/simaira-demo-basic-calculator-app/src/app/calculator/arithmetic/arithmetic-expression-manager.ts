import { Addition } from './addition';
import { Division } from './division';
import { Multiplication } from './multiplication';
import { INumericOperand } from './numeric-operand.interface';
import { Substraction } from './substraction';

export class ArithmeticExpressionManager {
    public static getNumericOperand(operator: string): INumericOperand {
        switch (operator) {
            case '+':
                return new Addition();
            case '*':
                return new Multiplication();
            case '/':
                return new Division();
            case '-':
                return new Substraction();
            default:
                throw new Error('Operation not supported');
        }
    }
}
