using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan16.Filters
{
    public class AdminFilters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Convert.ToBoolean(filterContext.HttpContext.Session["IsAdmin"]))
            {
                //filterContext.Result = new ContentResult { Content = "Unauthorized" };
                var Url = new UrlHelper(filterContext.RequestContext);
                var url = Url.Action("NotAuthentication", "Admin");
                filterContext.Result = new RedirectResult(url);
            }
        }
    }
}