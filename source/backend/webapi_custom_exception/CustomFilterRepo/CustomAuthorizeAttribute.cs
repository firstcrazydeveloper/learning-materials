using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;


namespace WEBAPI_Custom_Exception.CustomFilterRepo
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute  
    {
        
        private readonly string[] allowedroles;  
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {            
           
            if (allowedroles.Length == 0)
            {
                //actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                //actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

          
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            if (((System.Web.HttpContext.Current.User).Identity).IsAuthenticated)
            {
                filterContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }  
    }
}