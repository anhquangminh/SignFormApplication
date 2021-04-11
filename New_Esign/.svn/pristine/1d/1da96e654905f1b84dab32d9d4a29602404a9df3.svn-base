using New_Esign.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace New_Esign.Controllers
{
    public class BaseUserController : Controller
    {
        // GET: BaseUser
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
            Session.Timeout = 120;
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "LoginAccount", action = "Index", area = "" })
                    );
                base.OnActionExecuting(filterContext);
            }
        }
        // neu up code nen web chuyen controller = "CallBack", action = "Callback", area = ""
        // RouteValueDictionary(new { controller = "LoginAccount", action = "Index", area = "" })
        protected void setStatusVal(string val, string type)
        {
            TempData["backIndex"] = val;
            if (type == "PENDING")
            {
                TempData["backIndex"] = "p-3 mb-2 bg-info text-white";
            }
            else if (type == "CLOSED")
            {
                TempData["backIndex"] = "p-3 mb-2 bg-success text-white";
            }
            else
            {
                TempData["backIndex"] = "p-3 mb-2 bg-danger text-white";
            }
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
