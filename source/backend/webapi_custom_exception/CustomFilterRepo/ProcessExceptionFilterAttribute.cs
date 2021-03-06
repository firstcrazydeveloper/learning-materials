using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WEBAPI_Custom_Exception.CustomFilterRepo
{
    public class ProcessExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //Check the Exception Type

            if (actionExecutedContext.Exception is ProcessException)
            {
                //The Response Message Set by the Action During Ececution
                var res = actionExecutedContext.Exception.Message;

                //Define the Response Message
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(res),
                    ReasonPhrase = res,
                    StatusCode = HttpStatusCode.NotFound 
                };


                //Create the Error Response

                actionExecutedContext.Response = response;
                
            }
        }
    }

}
