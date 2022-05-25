using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility.Models;

namespace WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility
{
    public abstract class Approver
    {
        protected Approver successor;
        public string Messages;
        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchaseData);
    }
}