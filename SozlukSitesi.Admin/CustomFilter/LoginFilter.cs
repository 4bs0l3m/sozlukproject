using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SozlukSitesi.Admin.CustomFilter
{
    public class LoginFilter : FilterAttribute , IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext Context)
        {
            Context.HttpContext.Session["ZiyaretciIP"] = GetClientIp();
            //if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            //{
            //    Context.HttpContext.Session["ZiyaretciIP"] = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            //}
            //else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            //{
            //    Context.HttpContext.Session["ZiyaretciIP"] = HttpContext.Current.Request.UserHostAddress;
            //}
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var SessionsControl = Context.HttpContext.Session["kullaniciID"];
            if (SessionsControl==null)
            {
               Context.Result = new RedirectToRouteResult(
                  new RouteValueDictionary{{"Controller","Account"},{"action","Login"}});
            }
        }
        public string GetClientIp()
        {
            var ipAddress = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            { ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); }
            else if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null && 
                System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0) 
            { ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"]; } 
            else if (System.Web.HttpContext.Current.Request.UserHostAddress.Length != 0) 
            { ipAddress = System.Web.HttpContext.Current.Request.UserHostName; }
            return ipAddress;
        }
        public void OnActionExecuting(ActionExecutingContext Context)
        {
            //throw new NotImplementedException();
        }
    }
}