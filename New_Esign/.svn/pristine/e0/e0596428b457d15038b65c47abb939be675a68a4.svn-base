using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            if (!UserHelper.isLogged()) return RedirectToAction("Login", "Account", new { area = "" });
            return View();
        }
    }
}