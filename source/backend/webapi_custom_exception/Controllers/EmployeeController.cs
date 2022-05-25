using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_Custom_Exception.CustomFilterRepo;
using System.Web.Http.Description;
using WEBAPI_Custom_Exception.Models;
using WEBAPI_Custom_Exception.EmployeeService;
using WEBAPI_Custom_Exception.EntityObjects;
using System.Data.Objects;


namespace WEBAPI_Custom_Exception.Controllers
{
    [CustomAuthorize]
    [ActionSpeedProfiler]
    public class EmployeeController : ApiController
    {
        WebAPIEntities dbContext;
        EmployeeServiceClient client;
        public EmployeeController()
        {
            dbContext = new WebAPIEntities();
            client = new EmployeeServiceClient();
        }

        [CustomAuthorizeAttribute]
        public WEBAPI_Custom_Exception.EntityObjects.Employee Get(int id)
        {
            var demoFirst = dbContext.Students;
            var demo = dbContext.Students.Include("StudentContactDetail");
            var emp = dbContext.Employees.Find(id);
            var g = ObjectContext.GetObjectType(emp.GetType());
            //var emp = client.getEmployee(id);

            if (emp == null)
            {
                throw new ProcessException("Record Not Found, It may be removed");
            }
            return emp;
        }
    }
}
