using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility.Models;

namespace WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility
{
    public class Manager : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
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