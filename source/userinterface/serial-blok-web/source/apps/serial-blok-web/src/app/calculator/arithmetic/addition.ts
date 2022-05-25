import Big from "big.js";
import { INumericOperand } from "./numeric-operand.interface";

export class Addition implements INumericOperand {
    doAction(leftValue: Big, rightValue: Big): Big {
        return leftValue.add(rightValue);
    }
}