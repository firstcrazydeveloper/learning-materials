import Big from "big.js";
import { INumericOperand } from "./numeric-operand.interface";

export class Substraction implements INumericOperand {
    doAction(leftValue: Big, rightValue: Big): Big {
        return leftValue.minus(rightValue);
    }
}