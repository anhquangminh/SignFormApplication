using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewModel.Dao;
using New_Esign.Common;
using New_Esign.Models;
using System.Data;

namespace New_Esign.Controllers
{
    public class LoginAccountController : Controller
    {
        // GET: LoginAccount
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult loginAccount(LoginUserModel model)
        {
            var dao = new AccountDao();
            if (ModelState.IsValid)
            {
                
                var res = dao.Login(model.UserID.Trim(), model.PassWord);
                if(res == 1)
                {
                    var userSession = new UserLogin();
                    //var checkAu = dao.Login2(tes);
                    
                    var user = dao.GetByID(model.UserID.Trim());
                    userSession.UserID = user.UserID.Trim();
                    userSession.UserName = user.Username;
                    string idUser = user.UserID.Trim();


                    PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();
                    DataTable tb = new DataTable();
                    tb = postman.GetEmpInfomation(idUser);
                    string depart = tb.Rows[0]["CURRENT_OU_NAME"].ToString();
                    string costCode = tb.Rows[0]["CURRENT_OU_CODE"].ToString();
                    string mailUs = tb.Rows[0]["NOTES_ID"].ToString();
                    DateTime checkLeave =DateTime.Parse(tb.Rows[0]["LEAVEDAY"].ToString());
                    DateTime timeCheck = DateTime.Now;
                    if(timeCheck > checkLeave.AddMinutes(5))
                    {
                        string kq = " da nghi";
                    }
                    userSession.Department = depart;
                    userSession.CostCode = costCode;
                    userSession.Mail = mailUs;

                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    return RedirectToAction("WaitingForYourApproval", "APP_ESIGN", new { area = "Employee" });
                }
                else
                {
                    var checkAu = dao.Login2(model.UserID.Trim());
                    if (checkAu == 0)
                    {
                        Session["errorLog"] = "Ban khong co quyen vao he thong vui long lien he IT!";
                        return RedirectToAction("Index", "ErrorPage", new { area = "" });
                    }

                }
            }
            return View("Index");
        }
        public ActionResult LogoutUser()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Callback","CallBack",new { area=""});
        }
    }
}