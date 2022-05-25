using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBAPI_Custom_Exception.EmployeeService;
namespace WEBAPI_Custom_Exception.Models
{
    [MetadataType(typeof(EmployeeModelMetadata))]
    public partial class Employee
    {
        private class EmployeeModelMetadata
        {
            public int EmpNo { get; set; }
            [Required(ErrorMessage = "First Name is Must")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is Must")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Department is Must")]
            public string Department { get; set; }

            [Required(ErrorMessage = "Contact is Must")]
            public string Contact { get; set; }
        }
    }
}