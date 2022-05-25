import * as Lint from 'tslint';
import * as ts from 'typescript';

export class Rule extends Lint.Rules.AbstractRule {
    public static failureString = 'Forbidden string';

    public apply(sourceFile: ts.SourceFile): Lint.RuleFailure[] {
        return this.applyWithWalker(new ForbiddenStringsWalker(sourceFile, this.getOptions()));
    }
}

class ForbiddenStringsWalker extends Lint.RuleWalker {
    private isForbiddenWord(text: string): string {
        const forbiddenWord = this.getOptions().find((opt: { forbiddenString: string; suggestion: string }) => {
            return text.toUpperCase().includes(opt.forbiddenString.toUpperCase());
        }) as { forbiddenString: string; suggestion: string };

        let failureString: string;
        if (forbiddenWord && forbiddenWord.suggestion) {
            failureString = `${Rule.failureString}: '${forbiddenWord.forbiddenString}' - suggest to use '${forbiddenWord.suggestion}' instead`;
        } else if (forbiddenWord) {
            failureString = `${Rule.failureString}: '${forbiddenWord.forbiddenString}'`;
        }
        return failureString;
    }

    public visitReturnStatement(node: ts.ReturnStatement) {
        const failureString = this.isForbiddenWord(node.getText());
        if (failureString) {
            this.addFailureAtNode(node, failureString);
        }
        super.visitReturnStatement(node);
    }

    public visitVariableStatement(node: ts.VariableStatement) {
        const failureString = this.isForbiddenWord(node.getText());
        if (failureString) {
            this.addFailureAtNode(node, failureString);
        }
        super.visitVariableStatement(node);
    }

    public visitExpressionStatement(node: ts.ExpressionStatement) {
        const failureString = this.isForbiddenWord(node.getText());
        if (failureString) {
            this.addFailureAtNode(node, failureString);
        }
        super.visitExpressionStatement(node);
    }
}
