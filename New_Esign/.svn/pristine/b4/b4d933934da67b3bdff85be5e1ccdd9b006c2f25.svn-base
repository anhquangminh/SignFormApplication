using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using New_Esign.Common;
using New_Esign.Models;
using NewModel.Dao;
using OAuth2;
using Owin;

namespace New_Esign.Controllers
{
    public class CallBackController : Controller
    {
        // GET: CallBack
        private PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Callback()
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (Request.Params["error"] != null)
            {
                return RedirectToAction("Index", "ErrorPage", new { area = "" });
            }
            else if (Request.Params["code"] != null)
            {
                OAuthContext.Current.RequestToken(Request.Params["code"]);
                Dictionary<string, string> profile = OAuthContext.Current.profile;
                if (profile != null)
                {
                    if (Request.Params["state"] != null && Request.Params["state"].IndexOf("ReturnUrl=/") >= 0)
                    {
                        FormsAuthentication.SetAuthCookie(profile["username"] + '.' + profile["org"], false);

                        Response.Redirect(Request.Params["state"].Substring(11), true);

                    }
                    else
                    {
                        var dao = new AccountDao();
                        var tes = profile["username"].ToString();

                        DataTable tb = new DataTable();
                        tb = postman.GetEmpInfomation(tes);
                        DateTime checkLeave = DateTime.Parse(tb.Rows[0]["LEAVEDAY"].ToString());
                        DateTime timeCheck = DateTime.Now;
                        if (timeCheck > checkLeave.AddMinutes(5))
                        {
                            return RedirectToAction("CallBack", "Callback", new { area = " " });
                        }
                        var userSession = new UserLogin();
                        // var checkAu = dao.Login2(tes);
                        //if(checkAu == 0)
                        //{
                        //    Session["errorLog"] = "Ban khong co quyen vao he thong vui long lien he IT!";
                        //    return RedirectToAction("Index", "ErrorPage", new { area = "" });
                        //}
                        string name = tb.Rows[0]["USER_NAME"].ToString();
                        //var user = dao.GetByID(tes);
                        userSession.UserID = tes;
                        userSession.UserName = name;
                        //string idUser = user.UserID.Trim();


                        //PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();

                        string depart = tb.Rows[0]["CURRENT_OU_NAME"].ToString();
                        string costCode = tb.Rows[0]["CURRENT_OU_CODE"].ToString();
                        string mailUs = tb.Rows[0]["NOTES_ID"].ToString();
                        userSession.Department = depart;
                        userSession.CostCode = costCode;
                        userSession.Mail = mailUs;

                        Session.Add(CommonConstants.USER_SESSION, userSession);

                        return RedirectToAction("WaitingForYourApproval", "APP_ESIGN", new { area = "Employee" });
                    }
                }
                else
                {
                    return RedirectToAction("Index", "ErrorPage", new { area = "" });
                }

            }
            else
            {
                OAuthContext.Current.BeginAuth(Request.QueryString.ToString());
            }

            return View();

            //FormsAuthentication.SetAuthCookie(profile["username"] + '.' + profile["org"], false);
            //Dictionary<string, string> profile = OAuthContext.Current.profile;

        }


    }
}