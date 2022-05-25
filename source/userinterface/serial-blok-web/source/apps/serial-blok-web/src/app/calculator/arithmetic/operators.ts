export type Operator = '-' | '+' | '*' | '/' | '(' | ')';

export class Operators {
    
    public static isOperator(input: string): input is Operator {
        return input === '-' || input === '+' || input === '*' || input === '/' || input === '(' || input === ')';
      }
}