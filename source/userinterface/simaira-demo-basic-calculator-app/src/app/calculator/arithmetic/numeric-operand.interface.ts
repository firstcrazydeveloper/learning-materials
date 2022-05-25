import Big from "big.js";

export declare interface INumericOperand {
   doAction(leftValue: Big, rightValue: Big): Big;
}