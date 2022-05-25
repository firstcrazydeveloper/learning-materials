using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_Custom_Exception.CustomFilterRepo
{
    public class ProcessException:Exception
    {
        public ProcessException(string message)
            : base(message)
        {

        }
    }
}