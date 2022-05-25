using System;
using WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility.Models;

namespace WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility
{
    public class Accountant : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                this.Messages = string.Format("{0} approved request# {1}",
                  this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
}