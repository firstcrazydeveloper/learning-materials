using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBAPI_Custom_Exception.EntityObjects;
using WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility;
using WEBAPI_Custom_Exception.SampleCode.Behavior.ChainOfResponsebility.Models;

namespace WEBAPI_Custom_Exception.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            string message = "";
            ProcessFlowHandle pf = new ProcessFlowHandle();
            pf.CreateFlow("Normal");
            Purchase p = new Purchase(2034, 18000.00, "Assets");
            pf.ProcessRequest(p);
            message = pf.message;

            p = new Purchase(2035, 150000, "Project X");
            pf.ProcessRequest(p);
            message = pf.message;

            p = new Purchase(2036, 1500000, "Project Y");
            pf.ProcessRequest(p);
            message = pf.message;

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
