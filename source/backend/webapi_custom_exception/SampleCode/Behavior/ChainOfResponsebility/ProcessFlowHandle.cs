using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility.Models;

namespace WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility
{
    public class ProcessFlowHandle
    {
        Approver Level3;
        Approver Level2;
        Approver Level1;
        public string message { get; set; }

        public ProcessFlowHandle()
        {
            Level3 = new Director();
            Level2 = new Manager();
            Level1 = new Accountant();

        }

        public void ProcessRequest(Purchase purchase)
        {
            Level1.ProcessRequest(purchase);
            this.message = Level1.Messages;
        }

        public void CreateFlow(string process)
        {
            switch (process)
            {
                case "Normal":
                    Level1.SetSuccessor(Level2);
                    Level2.SetSuccessor(Level3);
                    break;

            }
        }
    }
}