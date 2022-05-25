import Big from "big.js";
import { INumericOperand } from "./numeric-operand.interface";

export class Multiplication implements INumericOperand {
    doAction(leftValue: Big, rightValue: Big): Big {
        return leftValue.mul(rightValue);
    }
}