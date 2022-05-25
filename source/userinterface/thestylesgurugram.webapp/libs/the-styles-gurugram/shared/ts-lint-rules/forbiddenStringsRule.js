'use strict';
var __extends =
    (this && this.__extends) ||
    (function () {
        var extendStatics = function (d, b) {
            extendStatics =
                Object.setPrototypeOf ||
                ({ __proto__: [] } instanceof Array &&
                    function (d, b) {
                        d.__proto__ = b;
                    }) ||
                function (d, b) {
                    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
                };
            return extendStatics(d, b);
        };
        return function (d, b) {
            extendStatics(d, b);
            function __() {
                this.constructor = d;
            }
            d.prototype = b === null ? Object.create(b) : ((__.prototype = b.prototype), new __());
        };
    })();
exports.__esModule = true;
var Lint = require('tslint');
var Rule = /** @class */ (function (_super) {
    __extends(Rule, _super);
    function Rule() {
        return (_super !== null && _super.apply(this, arguments)) || this;
    }
    Rule.prototype.apply = function (sourceFile) {
        return this.applyWithWalker(new ForbiddenStringsWalker(sourceFile, this.getOptions()));
    };
    Rule.failureString = 'Forbidden string';
    return Rule;
})(Lint.Rules.AbstractRule);
exports.Rule = Rule;
var ForbiddenStringsWalker = /** @class */ (function (_super) {
    __extends(ForbiddenStringsWalker, _super);
    function ForbiddenStringsWalker() {
        return (_super !== null && _super.apply(this, arguments)) || this;
    }
    ForbiddenStringsWalker.prototype.isForbiddenWord = function (text) {
        var forbiddenWord = this.getOptions().find(function (opt) {
            return text.toUpperCase().includes(opt.forbiddenString.toUpperCase());
        });
        var failureString;
        if (forbiddenWord && forbiddenWord.suggestion) {
            failureString = Rule.failureString + ": '" + forbiddenWord.forbiddenString + "' - suggest to use '" + forbiddenWord.suggestion + "' instead";
        } else if (forbiddenWord) {
            failureString = Rule.failureString + ": '" + forbiddenWord.forbiddenString + "'";
        }
        return failureString;
    };
    ForbiddenStringsWalker.prototype.visitReturnStatement = function (node) {
        var failureString = this.isForbiddenWord(node.getText());
        if (failureString) {
            this.addFailureAtNode(node, failureString);
        }
        _super.prototype.visitReturnStatement.call(this, node);
    };
    ForbiddenStringsWalker.prototype.visitVariableStatement = function (node) {
        var failureString = this.isForbiddenWord(node.getText());
        if (failureString) {
            this.addFailureAtNode(node, failureString);
        }
        _super.prototype.visitVariableStatement.call(this, node);
    };
    ForbiddenStringsWalker.prototype.visitExpressionStatement = function (node) {
        var failureString = this.isForbiddenWord(node.getText());
        if (failureString) {
            this.addFailureAtNode(node, failureString);
        }
        _super.prototype.visitExpressionStatement.call(this, node);
    };
    return ForbiddenStringsWalker;
})(Lint.RuleWalker);
