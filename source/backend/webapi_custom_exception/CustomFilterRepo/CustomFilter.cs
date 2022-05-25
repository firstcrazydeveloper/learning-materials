using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WEBAPI_Custom_Exception.CustomFilterRepo
{
    public class CustomFilter : FilterAttribute, IActionFilter
    {
        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            throw new NotImplementedException();
        }
       
    }
}