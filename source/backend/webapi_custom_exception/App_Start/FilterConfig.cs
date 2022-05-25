using System.Web;
using System.Web.Mvc;
using WEBAPI_Custom_Exception.CustomFilterRepo;

namespace WEBAPI_Custom_Exception
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ProcessExceptionFilterAttribute());
        }
    }
}