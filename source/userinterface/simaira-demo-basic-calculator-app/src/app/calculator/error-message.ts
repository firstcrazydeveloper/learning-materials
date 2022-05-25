export class ErrorMessage {
    private messages: Map<string, string>;

    public constructor() {
        this.setMessage();
    }

    private setMessage() {
        this.messages = new Map<string, string>();
        this.messages.set('[big.js] Division by zero', 'Division by zero');
    }

    public getErrorMEssage(key: string): string {
        if (this.messages.has(key)) {
            return this.messages.get(key);
        }
        return '';
    }
}
