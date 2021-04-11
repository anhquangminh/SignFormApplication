using NewModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using New_Esign.Areas.Employee.Models;
using New_Esign.Controllers;
using New_Esign.Common;
using System.Data;
using NewModel.Dao;
using System.IO;
using System.Data.SqlClient;
using New_Esign.AppCode;
using New_Esign.Areas.Employee.Controllers;

namespace New_Esign.Areas.Employee.Controllers
{
    public class MultiselectModel
    {
        [Required(ErrorMessage = "Value is required")]
        public string[] val { get; set; }
        public string[] data { get; set; }
    }

    public class ApplicationITController : BaseUserController
    {
        private DBConnectData db = new DBConnectData();

        private SendMail sendM = new SendMail();

        private Submit sb = new Submit();

        private PostmanService.PostmanServiceSoapClient postman = new PostmanService.PostmanServiceSoapClient();

        private NewCode newCode = new NewCode();

        private SQLServerDBHelper sqlHelp = new SQLServerDBHelper("DBConnectData");

        public string[] datasource = new string[] { "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker", "Tennis" };

        //private ApplicationHRController hrContr = new ApplicationHRController(this);
        // GET: Employee/ApplicationIT
        public ActionResult Index()
        {
            MultiselectModel model = new MultiselectModel();
            model.data = datasource;

            return View(model);
        }
        [HttpPost]
        public ActionResult MultiselectFor(MultiselectModel model)
        {
            model.data = datasource;
            model.val = model.val;

            string kq = model.val[1].ToString();
            string okku = " ";
            return View(model);
        }


        public ActionResult yellowApp()
        {
            ITRequestModel remodel = new ITRequestModel();

            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();


            DataTable table = new DataTable();
            table = postman.GetEmpInfomation(emp);

            remodel.EmpNo = emp;
            

            remodel.TimeStart = DateTime.Today;
            remodel.TimeEnd = DateTime.Today.AddMonths(6);
            remodel.Name = table.Rows[0]["USER_NAME"].ToString();
            remodel.CodeCost = table.Rows[0]["CURRENT_OU_CODE"].ToString();
            remodel.Depart = table.Rows[0]["CURRENT_OU_NAME"].ToString();
            remodel.Mail = table.Rows[0]["NOTES_ID"].ToString();

            string phone = newCode.getPhoneAccount(emp);
            if (!phone.Equals(""))
            {
                remodel.NumPhone = phone;
            }
            if (remodel.Mail.Equals(""))
            {
                string mail = newCode.getMailAccount(emp);
                if (!mail.Equals(""))
                {
                    remodel.Mail = mail;
                }

            }
            setViewSite();
            //setViewBu();
            setViewFactory();
            setViewFactoryApp();
            setViewLocaApp();
            return View(remodel);
        }

        [HttpPost]
        public ActionResult yellowApp(ITRequestModel Reqmodel)
        {
            try
            {

                setViewSite();
                //setViewBu();
                setViewFactory();
                setViewFactoryApp();
                // test multi

                setViewLocaApp();
                //var test3 = Reqmodel.AssetCode;        
                //var test2 = Reqmodel.LocationApply;

                ////1073741824
                //var testSign = HttpContext.Request.Form["testKQ"].ToString();
                //var testSign1 = HttpContext.Request.Form["testKQ1"].ToString();
                //var testSign2 = HttpContext.Request.Form["testKQ2"].ToString();
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var empCreate = session.UserID.Trim();
                if (ModelState.IsValid)
                {
                    if (Reqmodel.TimeStart > Reqmodel.TimeEnd)
                    {
                        ViewBag.ErrorTime = "有效結束時間不能小於開始時間 / Thời gian kết thúc không được nhỏ hơn thời gian bắt đầu";
                        return View(Reqmodel);
                    }
                    else if (Reqmodel.TimeEnd > Reqmodel.TimeStart.AddMonths(6))
                    {
                        ViewBag.ErrorTime = "有效期不超過6個月 / Thời gian kết thúc không được quá 6 tháng";
                        return View(Reqmodel);
                    }
                    Reqmodel.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateRandom(2);
                    var strDate = Reqmodel.TimeStart;
                    var site = Reqmodel.Site + Reqmodel.BU + Reqmodel.Location;
                    var files = Request.Files["file"];
                    //var files = null; 

                    if (files != null)
                    {
                        int fileSize = files.ContentLength;
                        if (fileSize > 2450000)
                        {
                            ViewBag.FileLimit = "上載檔案大小不得超過5Mb / Kích thước tệp tải lên không được quá 2Mb";
                            return View(Reqmodel);
                        }
                        String FileExt = Path.GetExtension(files.FileName).ToUpper();
                        string _fileName = Reqmodel.AppNo + Path.GetFileName(files.FileName);

                        String filePath = "/UploadFiles/" + _fileName;
                        string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _fileName);
                        //Stream str = files.InputStream;
                        //BinaryReader Br = new BinaryReader(str);
                        //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
                        //files.SaveAs(MapPath(filePath));
                        files.SaveAs(_path);

                        Reqmodel.filePath = filePath;
                        Reqmodel.fileName = files.FileName;


                    }


                    //check so dien thoai da co chua neu chua thi tu dong luu
                    string phone = newCode.getPhoneAccount(Reqmodel.EmpNo);
                    if (phone.Equals("") || Reqmodel.NumPhone != phone)
                    {
                        newCode.setPhoneAccount(Reqmodel.EmpNo, Reqmodel.NumPhone,Reqmodel.Name);
                    }
                    string mail = newCode.getMailAccount(Reqmodel.EmpNo);
                    if (mail.Equals("") || Reqmodel.Mail != mail)
                    {

                        newCode.setMailAccount(Reqmodel.EmpNo, Reqmodel.Mail,Reqmodel.Name);
                    }
                    // -- ket thuc luu so
                    DataTable table = new DataTable();
                    // lay thong tin xuong ap dung te m
                    //string[] checkLoca

                    string[] checkLocation = new string[3];



                    // lay thong tin chu quan bo phan

                    string[] managerDep = checkManager(Reqmodel.EmpNo).Split(';');
                    managerDep = managerDep.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    //fix luu trinh ky cho chi Hoa
                    //string[] managerDep = { "V0903271", "811641" };
                    //if (Reqmodel.EmpNo == "V0990965")
                    //{
                    //    //managerDep = { "V0903271";"811641" };
                    //}
                    string[] managerDepTitle = new string[managerDep.Length];

                    if (managerDep.Length > 1)
                    {
                        managerDepTitle[0] = "課級 / Cấp phòng"; managerDepTitle[1] = "部級 / Cấp bộ phận";
                    }
                    else
                    {
                        managerDepTitle[0] = " 部級 / Cấp bộ phận";
                    }

                    string[] signer = new string[8];
                    string[] signerTitle = new string[8];
                    string[] managerIT = newCode.getITEmp(Reqmodel.OfficeFac).Split(';');
                    string[] managerITtitle = { "會簽IT課長 / Trưởng phòng IT ", "會簽IT主管 / Chủ quản IT " };


                    Reqmodel.BU = " ";
                    Reqmodel.Site = " ";
                    string appcontent = " ";
                    switch (Reqmodel.ApplicationType)
                    {
                        case "USB":
                            {
                                Reqmodel.ComputerBrand = " ";
                                Reqmodel.ComputerSpeci = " ";
                                Reqmodel.SeriNum = " ";
                                Reqmodel.ColorPC = " ";
                                Reqmodel.factoryApply = " ";
                                Reqmodel.LocationApply = " ";
                                Reqmodel.KindofPC = " ";
                                Reqmodel.AssetCode = " ";
                                appcontent = "Open USB";

                                checkLocation = new string[1];
                                signer = new string[managerDep.Length + 6];
                                signerTitle = new string[managerDep.Length + 6];

                                signer[0] = Reqmodel.EmpNo;
                                signerTitle[0] = "申請人 / Người xin đơn";



                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerDep.Length; j++)
                                        {
                                            signer[i + j] = managerDep[j].ToString();
                                            signerTitle[i + j] = managerDepTitle[j].ToString();
                                        }
                                        break;
                                    }
                                }
                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "廠區IT負責員 / Nhân viên IT phụ trách nhà xưởng ";
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerIT.Length; j++)
                                        {
                                            signer[i + j] = managerIT[j].ToString();
                                            signerTitle[i + j] = managerITtitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {

                                        signer[i] = newCode.checkManagerLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "没有廠區主管信息 / Chưa có thông tin chủ quản xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "棟主 / Chủ xưởng  ";

                                        break;
                                    }

                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "結案單位IT / IT kết án ";
                                        break;
                                    }
                                }
                                break;
                                //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                //return View(Reqmodel);
                                // break;

                            }
                        case "AdminAcount":
                            {
                                Reqmodel.ComputerBrand = " ";
                                Reqmodel.ComputerSpeci = " ";
                                Reqmodel.USB_read = " ";
                                Reqmodel.SeriNum = " ";
                                Reqmodel.ColorPC = " ";
                                Reqmodel.factoryApply = " ";
                                Reqmodel.LocationApply = " ";
                                Reqmodel.KindofPC = " ";
                                Reqmodel.AssetCode = " ";

                                checkLocation = new string[1];
                                signer = new string[managerDep.Length + 6];
                                signerTitle = new string[managerDep.Length + 6];

                                signer[0] = Reqmodel.EmpNo;
                                signerTitle[0] = "申請人 / Người xin đơn";



                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerDep.Length; j++)
                                        {
                                            signer[i + j] = managerDep[j].ToString();
                                            signerTitle[i + j] = managerDepTitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "廠區IT負責員 / Nhân viên IT phụ trách nhà xưởng ";
                                        break;
                                    }
                                }


                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerIT.Length; j++)
                                        {
                                            signer[i + j] = managerIT[j].ToString();
                                            signerTitle[i + j] = managerITtitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {

                                        signer[i] = newCode.checkManagerLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "没有廠區主管信息 / Chưa có thông tin chủ quản xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "棟主 / Chủ xưởng ";

                                        break;
                                    }

                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "結案單位IT / IT kết án ";
                                        break;
                                    }
                                }

                                appcontent = "Authorize your account";
                                break;

                                //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                //return View(Reqmodel);
                                // break;
                            }
                        case "Port445":
                            {
                                Reqmodel.ComputerBrand = " ";
                                Reqmodel.ComputerSpeci = " ";
                                Reqmodel.USB_read = " ";
                                Reqmodel.SeriNum = " ";
                                Reqmodel.ColorPC = " ";
                                Reqmodel.factoryApply = " ";
                                Reqmodel.LocationApply = " ";
                                Reqmodel.KindofPC = " ";
                                Reqmodel.AssetCode = " ";

                                checkLocation = new string[1];
                                signer = new string[managerDep.Length + 6];
                                signerTitle = new string[managerDep.Length + 6];

                                signer[0] = Reqmodel.EmpNo;
                                signerTitle[0] = "申請人 / Người xin đơn";



                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerDep.Length; j++)
                                        {
                                            signer[i + j] = managerDep[j].ToString();
                                            signerTitle[i + j] = managerDepTitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "廠區IT負責員 / Nhân viên IT phụ trách nhà xưởng ";
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerIT.Length; j++)
                                        {
                                            signer[i + j] = managerIT[j].ToString();
                                            signerTitle[i + j] = managerITtitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {

                                        signer[i] = newCode.checkManagerLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "没有廠區主管信息 / Chưa có thông tin chủ quản xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "棟主 / Chủ xưởng ";

                                        break;
                                    }

                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "結案單位IT / IT kết án ";
                                        break;
                                    }
                                }

                                appcontent = "Open port 445";
                                break;
                                //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                //return View(Reqmodel);
                                // break;
                            }
                        case "OpenAccess":
                            {
                                Reqmodel.ComputerBrand = " ";
                                Reqmodel.ComputerSpeci = " ";
                                Reqmodel.USB_read = " ";
                                Reqmodel.SeriNum = " ";
                                Reqmodel.ColorPC = " ";
                                Reqmodel.factoryApply = " ";
                                Reqmodel.LocationApply = " ";
                                Reqmodel.KindofPC = " ";
                                Reqmodel.AssetCode = " ";

                                
                                checkLocation = new string[1];
                                signer = new string[ managerDep.Length + 6];
                                signerTitle = new string[ managerDep.Length + 6];

                                signer[0] = Reqmodel.EmpNo;
                                signerTitle[0] = "申請人 / Người xin đơn";

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerDep.Length; j++)
                                        {
                                            signer[i + j] = managerDep[j].ToString();
                                            signerTitle[i + j] = managerDepTitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "廠區IT負責員 / Nhân viên IT phụ trách nhà xưởng ";
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerIT.Length; j++)
                                        {
                                            signer[i + j] = managerIT[j].ToString();
                                            signerTitle[i + j] = managerITtitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {

                                        signer[i] = newCode.checkManagerLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "没有廠區主管信息 / Chưa có thông tin chủ quản xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "棟主 / Chủ xưởng ";

                                        break;
                                    }

                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "結案單位IT / IT kết án ";
                                        break;
                                    }
                                }

                                appcontent = "Open Access Permission";

                                break;
                                //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                //return View(Reqmodel);
                                //break;
                            }
                        case "addDHCP":
                            {
                                Reqmodel.ComputerBrand = " ";
                                Reqmodel.ComputerSpeci = " ";                                
                                Reqmodel.SeriNum = " ";
                                Reqmodel.ColorPC = " ";
                                Reqmodel.factoryApply = " ";
                                Reqmodel.LocationApply = " ";
                                Reqmodel.KindofPC = " ";
                                Reqmodel.AssetCode = " ";
                                Reqmodel.USB_read = Reqmodel.USB_Write;
                                if (Reqmodel.ComputerName == null) Reqmodel.ComputerName = "N/A";
                                if (Reqmodel.IPAdd == null) Reqmodel.IPAdd = "N/A";

                                checkLocation = new string[1];
                                signer = new string[2];
                                signerTitle = new string[2];

                                signer[0] = Reqmodel.EmpNo;
                                signerTitle[0] = "申請人 / Người xin đơn";

                                signer[1] = managerDep[0].ToString();
                                signerTitle[1] = managerDepTitle[0].ToString();                              

                                appcontent = "Add Mac DHCP";

                                break;
                                //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                //return View(Reqmodel);
                                //break;
                            }
                        case "yellowCard":
                            {
                                Reqmodel.USB_read = " ";
                                Reqmodel.ComputerName = " ";
                                Reqmodel.IPAdd = " ";
                                appcontent = "PC Yellow Card ";
                                Reqmodel.factoryApply = Reqmodel.OfficeFac;
                                //update Reqmodel.AssetCode == null
                                if (Reqmodel.AssetCode == null || Reqmodel.KindofPC == null)
                                {
                                    if (Reqmodel.AssetCode == null) ViewBag.AssetErr = "資產代碼 必要填寫的 -Mã tài sản không được để trống";
                                    if (Reqmodel.KindofPC == null) ViewBag.PCErr = "電腦類型 必要填寫的 -Loại máy tính không được để trống";

                                    return View(Reqmodel);
                                }

                                // tao luu trinh ky cho don the vang
                                checkLocation = Reqmodel.LocationApply.Split(';');
                                checkLocation = checkLocation.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                                signer = new string[checkLocation.Length + managerDep.Length + 5];
                                signerTitle = new string[checkLocation.Length + managerDep.Length + 5];
                                signer[0] = Reqmodel.EmpNo;
                                signerTitle[0] = "申請人 / Người xin đơn";

                                

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerDep.Length; j++)
                                        {
                                            signer[i + j] = managerDep[j].ToString();
                                            signerTitle[i + j] = managerDepTitle[j].ToString();
                                        }
                                        break;
                                    }
                                }

                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {

                                        signer[i] = newCode.checkManagerLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "没有廠區主管信息 / Chưa có thông tin chủ quản xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "所在棟主 / Chủ xưởng nơi mang đi ";

                                        break;
                                    }

                                }
                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < checkLocation.Length; j++)
                                        {
                                            signer[i + j] = newCode.checkManagerLo(checkLocation[j].ToString());
                                            if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                            {
                                                ViewBag.ErrorLoApply = "没有廠區主管信息 / Chưa có thông tin chủ quản xưởng " + checkLocation[j].ToString();
                                                return View(Reqmodel);
                                            }
                                            signerTitle[i + j] = "接待棟主 / Chủ xưởng nơi mang đến ";
                                        }
                                        break;
                                    }

                                }
                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        for (int j = 0; j < managerIT.Length; j++)
                                        {
                                            signer[i + j] = managerIT[j].ToString();
                                            signerTitle[i + j] = managerITtitle[j].ToString();
                                        }
                                        break;
                                    }
                                }
                                for (int i = 0; i < signer.Length; i++)
                                {
                                    if (signer[i] == null)
                                    {
                                        signer[i] = newCode.getITLo(Reqmodel.Location);
                                        if (signer[i].ToString().Equals("") || string.IsNullOrEmpty(signer[i].ToString()))
                                        {
                                            ViewBag.ErrorLoApply = "沒有結案單位IT信息 / Chưa có thông tin kỹ sư IT kết án xưởng " + Reqmodel.Location;
                                            return View(Reqmodel);
                                        }
                                        signerTitle[i] = "結案單位IT / IT kết án ";
                                        break;
                                    }
                                }
                                break;
                            } 
                    }
                    if (Reqmodel.fileName == null) Reqmodel.fileName = " ";
                    if (Reqmodel.filePath == null) Reqmodel.filePath = " ";
                    //delete
                    //sendM.insertSenmail(signer[1].Trim().ToString(), Reqmodel.AppNo, appcontent, signer[0].Trim().ToString(), "文件電子簽核申請單等待簽核");

                    string sqlQuery = @"insert into ITRequestTem(AppNo,EmpNo,Name,NumPhone,Site,BU,
        Depart,Mail,CodeCost,OfficeFac,Location,MacAd,ComputerSpeci,ComputerBrand,
    KindofPC,AssetCode,TimeStart,TimeEnd,ApplicationType,ComputerName,IPAdd,SeriNum,ColorPC,
    LocationApply,filePath,fileName,Reason,USB_Read,FactoryApply) values (@AppNo,@EmpNo,@Name,@NumPhone,@Site,@BU,
        @Depart,@Mail,@CodeCost,@OfficeFac,@Location,@MacAd,@ComputerSpeci,@ComputerBrand,
    @KindofPC,@AssetCode,@TimeStart,@TimeEnd,@ApplicationType,@ComputerName,@IPAdd,@SeriNum,@ColorPC,
    @LocationApply,@filePath,@fileName,@Reason,@USB_Read,@FactoryApply) ";
                    SqlParameter[] para = new SqlParameter[29];

                    para.SetValue(new SqlParameter("APPNO", Reqmodel.AppNo), 0);
                    para.SetValue(new SqlParameter("EmpNo", Reqmodel.EmpNo), 1);
                    para.SetValue(new SqlParameter("Name", Reqmodel.Name), 2);
                    para.SetValue(new SqlParameter("NumPhone", Reqmodel.NumPhone), 3);
                    para.SetValue(new SqlParameter("Site", Reqmodel.Site), 4);
                    para.SetValue(new SqlParameter("BU", Reqmodel.BU), 5);
                    para.SetValue(new SqlParameter("Depart", Reqmodel.Depart), 6);
                    para.SetValue(new SqlParameter("Mail", Reqmodel.Mail), 7);
                    para.SetValue(new SqlParameter("CodeCost", Reqmodel.CodeCost), 8);
                    para.SetValue(new SqlParameter("OfficeFac", Reqmodel.OfficeFac), 9);
                    para.SetValue(new SqlParameter("Location", Reqmodel.Location), 10);
                    para.SetValue(new SqlParameter("MacAd", Reqmodel.MacAd), 11);
                    para.SetValue(new SqlParameter("ComputerSpeci", Reqmodel.ComputerSpeci), 12);
                    para.SetValue(new SqlParameter("ComputerBrand", Reqmodel.ComputerBrand), 13);
                    para.SetValue(new SqlParameter("KindofPC", Reqmodel.KindofPC), 14);
                    para.SetValue(new SqlParameter("AssetCode", Reqmodel.AssetCode), 15);
                    para.SetValue(new SqlParameter("TimeStart", Reqmodel.TimeStart), 16);
                    para.SetValue(new SqlParameter("TimeEnd", Reqmodel.TimeEnd), 17);
                    para.SetValue(new SqlParameter("ApplicationType", Reqmodel.ApplicationType), 18);
                    para.SetValue(new SqlParameter("ComputerName", Reqmodel.ComputerName), 19);
                    para.SetValue(new SqlParameter("IPAdd", Reqmodel.IPAdd), 20);
                    para.SetValue(new SqlParameter("SeriNum", Reqmodel.SeriNum), 21);
                    para.SetValue(new SqlParameter("ColorPC", Reqmodel.ColorPC), 22);
                    para.SetValue(new SqlParameter("LocationApply", Reqmodel.LocationApply), 23);
                    para.SetValue(new SqlParameter("filePath", Reqmodel.filePath), 24);
                    para.SetValue(new SqlParameter("fileName", Reqmodel.fileName), 25);
                    para.SetValue(new SqlParameter("Reason", Reqmodel.Reason), 26);
                    para.SetValue(new SqlParameter("USB_Read", Reqmodel.USB_read), 27);
                    para.SetValue(new SqlParameter("FactoryApply", Reqmodel.factoryApply), 28);

                    bool kqSql = sqlHelp.ExcuteNonQuery(sqlQuery, para);
                    if (kqSql == true)
                    {
                        string sqlQueryLog = @"insert into ITRequestTem_log Select * From ITRequestTem Where APPNO ='" + Reqmodel.AppNo + "' ";
                        kqSql = sqlHelp.ExcuteNonQuery(sqlQueryLog);
                        if (kqSql == true)
                        {
                            string name = "";
                            for (int i = 0; i < signer.Length; i++)
                            {
                                name = getName(signer[i].Trim().ToString());
                                newCode.insertListSign(Reqmodel.AppNo, signer[i].Trim().ToString(), name, signerTitle[i].ToString(), i);
                            }
                            string signerName = getName(signer[1].ToString());
                            newCode.insertAppData(Reqmodel.AppNo, signerTitle[1].ToString(), Reqmodel.Name, signerName, DateTime.Now.ToString("yyyy/MM/dd HH:mm"), signer[1].ToString(), 29, 1, Reqmodel.EmpNo, appcontent, empCreate);


                            sb.f_submit_yellow("Submit", Reqmodel.AppNo, 29, Reqmodel.Name, Reqmodel.EmpNo, 0);

                            sendM.insertSenmail(signer[1].Trim().ToString(), Reqmodel.AppNo, appcontent, signer[0].Trim().ToString(), "文件電子簽核申請單等待簽核", appcontent);
                            sendM.insertSenmail(signer[0].Trim().ToString(), Reqmodel.AppNo, appcontent, signer[0].Trim().ToString(), "提交文件表格电子批准申请", Reqmodel.Mail);

                            //newCode.insertAppData(formIT01.AppNo, tbSignProcess.Rows[1]["SignName"].ToString(), name , formIT01.approvalApps[1].SignName, DateTime.Now.ToString("yyyy/MM/dd HH:mm"), formIT01.approvalApps[1].signEmpNo,formIT01.FormID,1, formIT01.Title4Content.Trim(), formIT01.Title20);
                            //sendM.insertSenmail1(formIT01.Title4Content.Trim(), formIT01.AppNo.Trim(), formIT01.Title20, formIT01.approvalApps[0].signEmpNo, "提交文件表格电子批准申请",formIT01.Title17Content);
                            return RedirectToAction("Index", "APP_ESIGN");
                        }
                        else
                        {
                            return RedirectToAction("Index", "ErrorPage", new { area = "" });
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "ErrorPage", new { area = "" });
                    }
                    
                }

                // thong bao loi 
                ViewBag.ErrorType = " 請填寫所有必填信息 / Vui lòng điền đầy đủ thông tin bắt buộc ";
                return View(Reqmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // form ky don tem vang
        public ActionResult formSign(string appNo)
        {
            ITRequestModel model = new ITRequestModel();
            model = newCode.requestModel(appNo);
            return View(model);
        }

        [HttpPost]
        public ActionResult formSign(ITRequestModel model, string ApprovalButton)
        {
            bool kq = true;
            bool kq2 = true;
            string sqlQuery = "";
            string checkWait = "";
            string applicant = "";
            if (model.USB_Write == null) model.USB_Write = " ";
            
            SendMail sen = new SendMail();
            switch (ApprovalButton)
            {
                case "Approval":
                    //kq = sb.f_insert_sub_yellow("通過", model.AppNo, model.USB_Write);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Approval", model.USB_Write);
                    DataTable dataTable = sb.f_get_desc(model.AppNo);
                    applicant = dataTable.Rows[0]["USEREMP"].ToString();
                    checkWait = dataTable.Rows[0]["Checkwait"].ToString();
                    
                    //update  dataTable2.Rows[0]["CHECKWAITNAME"].ToString()
                    sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單等待簽核");
                    break;
                case "Reject":
                    //kq = sb.f_insert_sub_yellow("駁回", model.AppNo, model.USB_Write);
                    kq2 = sb.SigningYellowCarD(model.AppNo, "Reject", model.USB_Write);
                    
                    //sqlQuery = @"select * from DATA_APP_ESIGN where APPNO='" + fORM_IT_.AppNo.Trim() + "' ;";
                    DataTable dataTable2 = sb.f_get_desc(model.AppNo);
                    applicant = dataTable2.Rows[0]["USEREMP"].ToString();
                    checkWait = dataTable2.Rows[0]["Checkwait"].ToString();
                    //SendMail sen2 = new SendMail();
                    bool kqsen = sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable2.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單被駁回");
                    //string kqte = "";
                    break;
                case "Submit":
                    {
                        //lay thong tin theo loai don
                        switch (model.ApplicationType)
                        {
                            case "USB":
                                {
                                    model.ComputerBrand = " ";
                                    model.ComputerSpeci = " ";
                                    model.SeriNum = " ";
                                    model.ColorPC = " ";
                                    model.factoryApply = " ";
                                    model.LocationApply = " ";
                                    model.KindofPC = " ";
                                    model.AssetCode = " ";
                                                                   
                                    break;
                                    //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                    //return View(Reqmodel);
                                    // break;

                                }
                            case "AdminAcount":
                                {
                                    model.ComputerBrand = " ";
                                    model.ComputerSpeci = " ";
                                    model.USB_read = " ";
                                    model.SeriNum = " ";
                                    model.ColorPC = " ";
                                    model.factoryApply = " ";
                                    model.LocationApply = " ";
                                    model.KindofPC = " ";
                                    model.AssetCode = " ";                                 
                                    break;

                                    //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                    //return View(Reqmodel);
                                    // break;
                                }
                            case "Port445":
                                {
                                    model.ComputerBrand = " ";
                                    model.ComputerSpeci = " ";
                                    model.USB_read = " ";
                                    model.SeriNum = " ";
                                    model.ColorPC = " ";
                                    model.factoryApply = " ";
                                    model.LocationApply = " ";
                                    model.KindofPC = " ";
                                    model.AssetCode = " "; 
                                    
                                    break;
                                    //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                    //return View(Reqmodel);
                                    // break;
                                }
                            case "OpenAccess":
                                {
                                    model.ComputerBrand = " ";
                                    model.ComputerSpeci = " ";
                                    model.USB_read = " ";
                                    model.SeriNum = " ";
                                    model.ColorPC = " ";
                                    model.factoryApply = " ";
                                    model.LocationApply = " ";
                                    model.KindofPC = " ";
                                    model.AssetCode = " ";


                                    break;
                                    //ViewBag.ErrorType = "  表单正在开发，请再次进入 / Mẫu đơn đang được phát triển, vui lòng quay lại sau  ";
                                    //return View(Reqmodel);
                                    //break;
                                }
                            case "yellowCard":
                                {
                                    model.USB_read = " ";
                                    model.ComputerName = " ";
                                    model.IPAdd = " ";                                    
                                   break;
                                }
                        }
                        var files = Request.Files["file"];
                        if (files != null)
                        {
                            int fileSize = files.ContentLength;
                            if (fileSize > 2000000)
                            {
                                ViewBag.FileLimit = "上載檔案大小不得超過2Mb / Kích thước tệp tải lên không được quá 2Mb";
                                return View(model);
                            }
                            String FileExt = Path.GetExtension(files.FileName).ToUpper();
                            string _fileName = model.AppNo + Path.GetFileName(files.FileName);

                            String filePath = "/UploadFiles/" + _fileName;
                            string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _fileName);
                            //Stream str = files.InputStream;
                            //BinaryReader Br = new BinaryReader(str);
                            //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
                            //files.SaveAs(MapPath(filePath));
                            files.SaveAs(_path);
                            string link = filePath;

                            string[] linkQ = link.Split('.');
                            if(linkQ.Length > 1)
                            {
                                model.fileName = files.FileName;
                                model.filePath = link;
                            }
                        }
                        if (model.fileName == null) model.fileName = " ";
                        if (model.filePath == null) model.filePath = " ";


                        string strQuery = @"update ITRequestTem set NumPhone = @NumPhone,
        MacAd=@MacAd,ComputerSpeci=@ComputerSpeci,ComputerBrand=@ComputerBrand,
    KindofPC=@KindofPC,AssetCode=@AssetCode,ComputerName=@ComputerName,IPAdd=@IPAdd,SeriNum=@SeriNum,ColorPC=@ColorPC,
   filePath=@filePath,fileName=@fileName,Reason=@Reason where AppNo='"+ model.AppNo + "' ";
                        SqlParameter[] para = new SqlParameter[13];

                        para.SetValue(new SqlParameter("NumPhone", model.NumPhone), 0);                        
                        para.SetValue(new SqlParameter("MacAd", model.MacAd), 1);
                        para.SetValue(new SqlParameter("ComputerSpeci", model.ComputerSpeci), 2);
                        para.SetValue(new SqlParameter("ComputerBrand", model.ComputerBrand), 3);
                        para.SetValue(new SqlParameter("KindofPC", model.KindofPC), 4);
                        para.SetValue(new SqlParameter("AssetCode", model.AssetCode), 5);
                        para.SetValue(new SqlParameter("ComputerName", model.ComputerName), 6);
                        para.SetValue(new SqlParameter("IPAdd", model.IPAdd), 7);
                        para.SetValue(new SqlParameter("SeriNum", model.SeriNum), 8);
                        para.SetValue(new SqlParameter("ColorPC", model.ColorPC), 9);
                        para.SetValue(new SqlParameter("filePath", model.filePath), 10);
                        para.SetValue(new SqlParameter("fileName", model.fileName), 11);
                        para.SetValue(new SqlParameter("Reason", model.Reason), 12);

                        bool kqSql = sqlHelp.ExcuteNonQuery(strQuery, para);

                        kq2 = sb.SigningYellowCarD(model.AppNo, "Approval", model.USB_Write);

                        DataTable dataTable4 = sb.f_get_desc(model.AppNo);
                        checkWait = dataTable4.Rows[0]["Checkwait"].ToString();                        
                        //update  dataTable2.Rows[0]["CHECKWAITNAME"].ToString()
                        sen.insertSenmail(checkWait.Trim(), model.AppNo.Trim(), dataTable4.Rows[0]["Title"].ToString(), applicant, "文件電子簽核申請單等待簽核");

                        break;
                    }
                    
                case "Delete":
                    {
                        sqlQuery = @"update [dbo].[DATA_APP_ESIGN] set APPSTATUS = N'駁回'  checkwait = N'駁回' where appno='" + model.AppNo.Trim()+"'";
                        sqlHelp.ExcuteNonQuery(sqlQuery);
                        break;
                    }                   

                
            }
            return RedirectToAction("WaitingForYourApproval", "APP_ESIGN");

        }

        //Mau don khai bao ban quyen phan mềm
        public ActionResult sftDeclare()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var emp = session.UserID.Trim();
            FORM_IT_01Model conModel = new FORM_IT_01Model();
            //var formName = "FORM_HR_01";
            //var formID = newCode.getFormID(formName);
            DataTable table = new DataTable();
            table = postman.GetEmpInfomation(emp);

            conModel.empName = table.Rows[0]["USER_NAME"].ToString();
            conModel.Title3Content = table.Rows[0]["CURRENT_OU_NAME"].ToString();
            conModel.Title4Content = table.Rows[0]["CURRENT_OU_CODE"].ToString();

            conModel.Title1Content = table.Rows[0]["NOTES_ID"].ToString();
            string phone = newCode.getPhoneAccount(emp);
            if (!phone.Equals(""))
            {
                conModel.Title2Content = phone;
            }
            if (conModel.Title1Content.Equals("") || conModel.Title1Content == null)
            {
                string mail = newCode.getMailAccount(emp);
                if (!mail.Equals(""))
                {
                    conModel.Title1Content = mail;
                }
            }
            //setViewBu();
            setViewFactoryDec();
            setViewFactoryApp();
            // test multi
            conModel.empID = emp;
            setViewLocaApp();
            //conModel = hrContr.contactModel(formID);
            return View(conModel);
        }

        // post ky don tem vang
        [HttpPost]
        public ActionResult sftDeclare(FORM_IT_01Model conModel)
        {
            try
            {
                var conF = Request.Files["confirm"];
                setViewFactoryDec();
                setViewFactoryApp();
                // test multi
                
                setViewLocaApp();
                //lay thong tin nguoi dien don
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                var emp = session.UserID.Trim();
                //lay ma dau don
                conModel.AppNo = DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateRandom(2);

                //tu dong lay thong tin dien thoai
                string phone = newCode.getPhoneAccount(conModel.empID);

                if (phone.Equals("") || conModel.Title2Content != phone)
                {
                    newCode.setPhoneAccount(conModel.empID, conModel.Title2Content, conModel.empName);
                }
                string mail = newCode.getMailAccount(conModel.empID.Trim());
                if (mail.Equals("") || conModel.Title1Content != mail)
                {
                    newCode.setMailAccount(conModel.empID.Trim(), conModel.Title1Content, conModel.empName);
                }

                //lay thong tin file
                var files = Request.Files["file"];
                if (files != null)
                {
                    int fileSize = files.ContentLength;
                    if (fileSize > 2000000)
                    {
                        ViewBag.FileLimit = "上載檔案大小不得超過2Mb / Kích thước tệp tải lên không được quá 2Mb";
                        return View(conModel);
                    }
                    String FileExt = Path.GetExtension(files.FileName).ToUpper();
                    string _fileName = conModel.AppNo + Path.GetFileName(files.FileName);

                    String filePath = "/UploadFiles/" + _fileName;
                    string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _fileName);
                    //Stream str = files.InputStream;
                    //BinaryReader Br = new BinaryReader(str);
                    //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
                    //files.SaveAs(MapPath(filePath));
                    files.SaveAs(_path);

                    conModel.Title8 = filePath;
                    conModel.Title9 = files.FileName;
                }
                if (conModel.Title9 == null) conModel.Title9 = " ";
                string titleContent = conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";";
                titleContent += conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";";
                titleContent += conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";";
                titleContent += conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";";
                titleContent += conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";" + conModel.empID + ";";

                string timeApply = conModel.Title7Content + "-" + conModel.Title8Content;

                conModel.Title7 = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                string[] arrayContent = titleContent.Split(';');

                DataTable tbTitleform = new DataTable();

                string strtbTitleform = @"select * from TitleForm where FormID='33' ;";
                tbTitleform = sqlHelp.DoSQLSelect(strtbTitleform);

                using (SqlConnection conn = new SqlConnection(@"Data Source=10.224.81.131,3000;Initial Catalog=esign;Persist Security Info=True;User ID=sa;Password=foxconn168!!"))
                {
                    bool checkReasonFlag = false;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {

                        string strQueryDecl = @"insert into SoftWareDeclare(AppNo,UserNo,UserName,UserPhone,UserMail,UserDept,Applicant,swName,Version,Reason,Location,IP,computerType,operatingSystem,systemType,filePath,fileName,TimeCreate,Factory,CodeCost,Depart)
values (@AppNo,@UserNo,@UserName,@UserPhone,@UserMail,@UserDept,@Applicant,@swName,@Version,@Reason,@Location,@IP,@computerType,@operatingSystem,@systemType,@filePath,@fileName,@TimeCreate,@Factory,@CodeCost,@Depart)";

                        SqlCommand cmd = new SqlCommand(strQueryDecl, conn);
                        cmd.Transaction = trans;

                        SqlParameter[] para = new SqlParameter[21];
                        para.SetValue(new SqlParameter("AppNo", conModel.AppNo), 0);
                        para.SetValue(new SqlParameter("UserNo", conModel.empID), 1);
                        para.SetValue(new SqlParameter("UserName", conModel.empName), 2);
                        para.SetValue(new SqlParameter("UserPhone", conModel.Title2Content), 3);
                        para.SetValue(new SqlParameter("UserMail", conModel.Title1Content), 4);

                        para.SetValue(new SqlParameter("UserDept", conModel.Title3Content), 5);
                        para.SetValue(new SqlParameter("Applicant", emp), 6);
                        para.SetValue(new SqlParameter("swName", conModel.Title6Content), 7);
                        para.SetValue(new SqlParameter("Version", conModel.Title19Content), 8);
                        para.SetValue(new SqlParameter("Reason", conModel.Title13Content), 9);

                        para.SetValue(new SqlParameter("fileName", conModel.Title9), 10);
                        para.SetValue(new SqlParameter("Location", conModel.Title5Content), 11);
                        para.SetValue(new SqlParameter("IP", conModel.Title15Content), 12);
                        para.SetValue(new SqlParameter("computerType", conModel.Title9Content), 13);
                        para.SetValue(new SqlParameter("operatingSystem", conModel.Title11Content), 14);

                        para.SetValue(new SqlParameter("systemType", conModel.Title10Content), 15);
                        para.SetValue(new SqlParameter("filePath", conModel.Title8), 16);
                        para.SetValue(new SqlParameter("TimeCreate", conModel.Title7), 17);
                        para.SetValue(new SqlParameter("Factory", conModel.Title14Content), 18);
                        para.SetValue(new SqlParameter("CodeCost", conModel.Title4Content), 19);
                        para.SetValue(new SqlParameter("Depart", timeApply), 20);
                        cmd.Parameters.AddRange(para);
                        //para.SetValue(new SqlParameter("fileName", Reqmodel.USB_read), 17);
                        int rowAff = cmd.ExecuteNonQuery();
                        if (rowAff > 0)
                        {                            
                                checkReasonFlag = true;
                            string strQueryDeclLog = @"insert into SoftWareDeclare_log(AppNo,UserNo,UserName,UserPhone,UserMail,UserDept,Applicant,swName,Version,Reason,Location,IP,computerType,operatingSystem,systemType,filePath,fileName,TimeCreate,Factory,CodeCost,Depart)
values (@AppNo,@UserNo,@UserName,@UserPhone,@UserMail,@UserDept,@Applicant,@swName,@Version,@Reason,@Location,@IP,@computerType,@operatingSystem,@systemType,@filePath,@fileName,@TimeCreate,@Factory,@CodeCost,@Depart)";

                            SqlCommand cmdLog = new SqlCommand(strQueryDeclLog, conn);
                            cmdLog.Transaction = trans;

                            SqlParameter[] paraLog = new SqlParameter[21];
                            paraLog.SetValue(new SqlParameter("AppNo", conModel.AppNo), 0);
                            paraLog.SetValue(new SqlParameter("UserNo", conModel.empID), 1);
                            paraLog.SetValue(new SqlParameter("UserName", conModel.empName), 2);
                            paraLog.SetValue(new SqlParameter("UserPhone", conModel.Title2Content), 3);
                            paraLog.SetValue(new SqlParameter("UserMail", conModel.Title1Content), 4);

                            paraLog.SetValue(new SqlParameter("UserDept", conModel.Title3Content), 5);
                            paraLog.SetValue(new SqlParameter("Applicant", emp), 6);
                            paraLog.SetValue(new SqlParameter("swName", conModel.Title6Content), 7);
                            paraLog.SetValue(new SqlParameter("Version", conModel.Title19Content), 8);
                            paraLog.SetValue(new SqlParameter("Reason", conModel.Title13Content), 9);

                            paraLog.SetValue(new SqlParameter("fileName", conModel.Title9), 10);
                            paraLog.SetValue(new SqlParameter("Location", conModel.Title5Content), 11);
                            paraLog.SetValue(new SqlParameter("IP", conModel.Title15Content), 12);
                            paraLog.SetValue(new SqlParameter("computerType", conModel.Title9Content), 13);
                            paraLog.SetValue(new SqlParameter("operatingSystem", conModel.Title11Content), 14);

                            paraLog.SetValue(new SqlParameter("systemType", conModel.Title10Content), 15);
                            paraLog.SetValue(new SqlParameter("filePath", conModel.Title8), 16);
                            paraLog.SetValue(new SqlParameter("TimeCreate", conModel.Title7), 17);
                            paraLog.SetValue(new SqlParameter("Factory", conModel.Title14Content), 18);
                            paraLog.SetValue(new SqlParameter("CodeCost", conModel.Title4Content), 19);
                            paraLog.SetValue(new SqlParameter("Depart", timeApply), 20);

                            cmdLog.Parameters.AddRange(paraLog);
                            //para.SetValue(new SqlParameter("fileName", Reqmodel.USB_read), 17);
                            

                                int rowAffLog = cmdLog.ExecuteNonQuery();
                                if (rowAffLog > 0)
                                {
                                    checkReasonFlag = true;
                                }
                                else
                                    checkReasonFlag = false;                            
                        }
                        else
                            checkReasonFlag = false;
                        // them vao bang
                        
                        //
                        if (checkReasonFlag == true)
                        {
                            trans.Commit();
                            conn.Close();
                            return RedirectToAction("ListSoftWare", "APP_ESIGN");
                        }
                        else
                        {
                            trans.Rollback();
                            conn.Close();
                            return View("ContactForm");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            return View();
        }

        //Kiem tra thong tin don 
        public ActionResult sftCheck(string AppNo)
        {
            FORM_IT_01Model model = new FORM_IT_01Model();

            model = newCode.sftData(AppNo);


            return View(model);
        }

        //lay danh sach Site
        public void setViewSite(long? selectedID = null)
        {
            var dao = new CodeDao();
            ViewBag.Site = new SelectList(dao.ListSite(), "SiteName", "SiteName", selectedID);
        }

        //Lay danh sach BU theo Site
        //public void setViewBu(long? selectedID = null)
        //{
        //    var dao = new CodeDao();
        //    ViewBag.BU = new SelectList(dao.ListBU(), "BUName", "BUName", selectedID);
        //}

        public JsonResult setViewBuKh(string SiteName)
        {
            db.Configuration.ProxyCreationEnabled = false;
            string sqlQuery = @"select * from Site where SiteName = '" + SiteName + "' ";
            DataTable table = sqlHelp.DoSQLSelect(sqlQuery);
            string siteID = table.Rows[0]["SiteID"].ToString();
            List<BU> projectList = db.BUs.Where(x => x.SiteID == siteID).ToList();
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }
        //Lay danh sach xuong
        public JsonResult getLocation(string facID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Location_Fac> projectList = newCode.ListLoca(facID);
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }
        //lay du lieu khu vuc ap dung
        public void setViewFactoryApp(long? selectedID = null)
        {

            ViewBag.factoryApply = new SelectList(newCode.listFac(), "Factory_name", "Factory_name", selectedID);
        }

        //tét lay du lieu location
        //lay du lieu khu vuc ap dung
        public void setViewLocaApp(long? selectedID = null)
        {

            ViewBag.locationMulti = new SelectList(newCode.ListLoca(), "Location", "Location", selectedID);
        }

        //lay danh sach xuong theo ten khu vuc ap dung
        public JsonResult getLocatApp(string facID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Location_Fac> projectList = newCode.ListLoca(facID);
            return Json(projectList, JsonRequestBehavior.AllowGet);
        }

        //lay du lieu nhan vien it quan ly xuong
        public JsonResult getEmpManIT(string fac)
        {
            if (fac == null) fac = "越南-桂武";
            string listEmp = newCode.getITEmp(fac);
            string[] arrayEmp = listEmp.Split(';');
            string emp = arrayEmp[1].ToString();
            string empName = getName(emp);

            List<string> empInfor = new List<string>() {emp,empName};
            
            
            return Json(empInfor, JsonRequestBehavior.AllowGet);
        }

        //lay thong tin chu quan bu bang json
        public JsonResult getEmpMBU(string empNo)
        {
            DataTable table = new DataTable();
            table = postman.GetEmpInfomation(empNo);
            string SITE_ALL_MANAGERS = table.Rows[0]["SITE_ALL_MANAGERS"].ToString();
            int levelEmp = checkLevel(empNo);

            string[] manageEmpNo2 = SITE_ALL_MANAGERS.Split(';');
            string mangager_emp = "";
            if (levelEmp > 19)
            {
                mangager_emp = empNo;
            }
            else
            {               
                for (int i = 0; i < manageEmpNo2.Length; i++)
                {
                    int level = checkLevel(manageEmpNo2[i].ToString());
                    if (level > 19 && level < 29)
                    {
                        mangager_emp += manageEmpNo2[i].ToString();
                        break;
                    }
                }
            }
            string emp = mangager_emp;
            string empName = getName(emp);

            List<string> empInfor = new List<string>() { emp, empName };


            return Json(empInfor, JsonRequestBehavior.AllowGet);
        }

        //lay du lieu xuong
        public void setViewFactory(long? selectedID = null)
        {

            ViewBag.OfficeFac = new SelectList(newCode.listFac(), "Factory_name", "Factory_name", selectedID);
        }

        public void setViewFactoryData(long? selectedID = null)
        {

            ViewBag.Title4 = new SelectList(newCode.listFac(), "Factory_name", "Factory_name", selectedID);
        }
        // lay du lieu xuong cho declare
        public void setViewFactoryDec(long? selectedID = null)
        {
            ViewBag.Title14Content = new SelectList(newCode.listFac(), "Factory_name", "Factory_name", selectedID);
        }

        //lay random madau don
        public static char[] constant =
        {
        '0','1','2','3','4','5','6','7','8','9'
        };
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }

        public int checkLevel(string empNo)
        {
            DataTable table = new DataTable();
            table = postman.GetEmpInfomation(empNo);
            string level = table.Rows[0]["USER_LEVEL"].ToString();

            int lev = Convert.ToInt32(level);
            return lev;
        }

        public string getName(string empNo)
        {
            DataTable table = new DataTable();
            table = postman.GetEmpInfomation(empNo);
            string name = table.Rows[0]["USER_NAME"].ToString();

            return name;
        }

        public string checkManager(string empNo)
        {
            DataTable table = new DataTable();
            table = postman.GetEmpInfomation(empNo);
            string SITE_ALL_MANAGERS = table.Rows[0]["SITE_ALL_MANAGERS"].ToString();
            int levelEmp = checkLevel(empNo);

            string[] manageEmpNo2 = SITE_ALL_MANAGERS.Split(';');
            string mangager_emp = "";
            if (levelEmp > 19)
            {
                mangager_emp = empNo + ";";
            }
            else
            {
                if (empNo == "V0957033" || empNo == "V0990965")
                {
                    for (int i = 0; i < manageEmpNo2.Length; i++)
                    {
                        int level = checkLevel(manageEmpNo2[i].ToString());
                        if (level == 0)
                        {
                            mangager_emp +=  "V0957033;";
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < manageEmpNo2.Length; i++)
                    {
                        int level = checkLevel(manageEmpNo2[i].ToString());
                        if (level > 9)
                        {
                            mangager_emp += manageEmpNo2[i].ToString() + ";";
                            break;
                        }
                    }
                }

                for (int i = 0; i < manageEmpNo2.Length; i++)
                {
                    int level = checkLevel(manageEmpNo2[i].ToString());
                    if (level > 19 && level < 29)
                    {
                        mangager_emp += manageEmpNo2[i].ToString() + ";";
                        break;
                    }
                }
            }

            if (mangager_emp.Equals(""))
            {
                mangager_emp = "NULL";
            }
            else
            {
                string[] checkManager = mangager_emp.Split(';');
                if (checkManager[0].ToString() == checkManager[1].ToString())
                {
                    mangager_emp = checkManager[0].ToString();
                }
            }

            return mangager_emp;
        }

        public string checkMangagerDecla(string empNo)
        {
            DataTable table = new DataTable();
            table = postman.GetEmpInfomation(empNo);
            string SITE_ALL_MANAGERS = table.Rows[0]["SITE_ALL_MANAGERS"].ToString();
            int levelEmp = checkLevel(empNo);

            string[] manageEmpNo2 = SITE_ALL_MANAGERS.Split(';');
            string mangager_emp = "";

            if (levelEmp > 9)
            {
                mangager_emp = empNo ;
            }
            else
            {
                mangager_emp = manageEmpNo2[0].ToString();
            }
            return mangager_emp;
        }

        public ActionResult DatalistPC()
        {
            setViewFactoryData();
            
            return View();
        }

        [HttpPost]
        public ActionResult DataListPC(FORM_IT_01Model fORM_IT)
        {

            setViewFactoryData();
            string[] arrayFileName = fORM_IT.Title4Example.Split(',');
            string[] arrayPath = fORM_IT.Title5Example.Split(',');
            string[] arrayLenght = fORM_IT.Title6Example.Split(',');
            string[] arraySer = fORM_IT.Title6Example.Split(',');
            string[] arrayDesc = fORM_IT.Title6Example.Split(',');

            int pat = arrayPath.Length;
            int len = arrayLenght.Length;
            int ser = arraySer.Length;
            int des = arrayDesc.Length;

            int[] arrayCheck = { arrayFileName.Length ,pat,len,ser,des};
            int check = arrayCheck[0];
            string res = "Loi roi";
            for(int i=0;i<arrayCheck.Length;i++)
            {
                if (check != arrayCheck[i]) { res = " Error "; break; }
            }

//            using (SqlConnection conn = new SqlConnection(@"Data Source=10.224.81.131,3000;Initial Catalog=esign;Persist Security Info=True;User ID=sa;Password=foxconn168!!"))
//            {
//                bool checkReasonFlag = false;
//                if (conn.State != ConnectionState.Open) conn.Open();
//                using (SqlTransaction trans = conn.BeginTransaction())
//                {

//                    string strQueryDecl = @"insert into ListDataPC(AppNo,EmpNo,EmpName,Dept,JobTitle,Mail,Factory,Location,Descript) values (@AppNo,@EmpNo,@EmpName,@Dept,@JobTitle,@Mail,@Factory,@Location,@Descript)";

//                    SqlCommand cmd = new SqlCommand(strQueryDecl, conn);
//                    cmd.Transaction = trans;

//                    SqlParameter[] para = new SqlParameter[21];
//                    para.SetValue(new SqlParameter("AppNo", fORM_IT.AppNo), 0);
//                    para.SetValue(new SqlParameter("EmpNo", fORM_IT.empID), 0);
//                    para.SetValue(new SqlParameter("EmpName", fORM_IT.empName), 0);
//                    para.SetValue(new SqlParameter("JobTitle", fORM_IT.Title1), 0);
//                    para.SetValue(new SqlParameter("Dept", fORM_IT.Title3), 0);

//                    para.SetValue(new SqlParameter("AppNo", fORM_IT.Title2), 0);
//                    para.SetValue(new SqlParameter("Factory", fORM_IT.Title4), 0);
//                    para.SetValue(new SqlParameter("Location", fORM_IT.Title5), 0);
//                    para.SetValue(new SqlParameter("Mail", fORM_IT.Title0), 0);
//                    cmd.Parameters.AddRange(para);
//                    //para.SetValue(new SqlParameter("fileName", Reqmodel.USB_read), 17);
//                    int rowAff = cmd.ExecuteNonQuery();
//                    if (rowAff > 0)
//                    {
//                        checkReasonFlag = true;
//                        string strQueryDeclLog = @"insert into SoftWareDeclare_log(AppNo,UserNo,UserName,UserPhone,UserMail,UserDept,Applicant,swName,Version,Reason,Location,IP,computerType,operatingSystem,systemType,filePath,fileName,TimeCreate,Factory,CodeCost,Depart)
//values (@AppNo,@UserNo,@UserName,@UserPhone,@UserMail,@UserDept,@Applicant,@swName,@Version,@Reason,@Location,@IP,@computerType,@operatingSystem,@systemType,@filePath,@fileName,@TimeCreate,@Factory,@CodeCost,@Depart)";

//                        SqlCommand cmdLog = new SqlCommand(strQueryDeclLog, conn);
//                        cmdLog.Transaction = trans;

//                        SqlParameter[] paraLog = new SqlParameter[21];
//                        paraLog.SetValue(new SqlParameter("AppNo", conModel.AppNo), 0);
//                        paraLog.SetValue(new SqlParameter("UserNo", conModel.empID), 1);
//                        paraLog.SetValue(new SqlParameter("UserName", conModel.empName), 2);
//                        paraLog.SetValue(new SqlParameter("UserPhone", conModel.Title2Content), 3);
//                        paraLog.SetValue(new SqlParameter("UserMail", conModel.Title1Content), 4);

//                        paraLog.SetValue(new SqlParameter("UserDept", conModel.Title3Content), 5);
//                        paraLog.SetValue(new SqlParameter("Applicant", emp), 6);
//                        paraLog.SetValue(new SqlParameter("swName", conModel.Title6Content), 7);
//                        paraLog.SetValue(new SqlParameter("Version", conModel.Title19Content), 8);
//                        paraLog.SetValue(new SqlParameter("Reason", conModel.Title13Content), 9);

//                        paraLog.SetValue(new SqlParameter("fileName", conModel.Title9), 10);
//                        paraLog.SetValue(new SqlParameter("Location", conModel.Title5Content), 11);
//                        paraLog.SetValue(new SqlParameter("IP", conModel.Title15Content), 12);
//                        paraLog.SetValue(new SqlParameter("computerType", conModel.Title9Content), 13);
//                        paraLog.SetValue(new SqlParameter("operatingSystem", conModel.Title11Content), 14);

//                        paraLog.SetValue(new SqlParameter("systemType", conModel.Title10Content), 15);
//                        paraLog.SetValue(new SqlParameter("filePath", conModel.Title8), 16);
//                        paraLog.SetValue(new SqlParameter("TimeCreate", conModel.Title7), 17);
//                        paraLog.SetValue(new SqlParameter("Factory", conModel.Title14Content), 18);
//                        paraLog.SetValue(new SqlParameter("CodeCost", conModel.Title4Content), 19);
//                        paraLog.SetValue(new SqlParameter("Depart", timeApply), 20);

//                        cmdLog.Parameters.AddRange(paraLog);
//                        //para.SetValue(new SqlParameter("fileName", Reqmodel.USB_read), 17);


//                        int rowAffLog = cmdLog.ExecuteNonQuery();
//                        if (rowAffLog > 0)
//                        {
//                            checkReasonFlag = true;
//                        }
//                        else
//                            checkReasonFlag = false;
//                    }
//                    else
//                        checkReasonFlag = false;
//                    // them vao bang

//                    //
//                    if (checkReasonFlag == true)
//                    {
//                        trans.Commit();
//                        conn.Close();
//                        return RedirectToAction("ListSoftWare", "APP_ESIGN");
//                    }
//                    else
//                    {
//                        trans.Rollback();
//                        conn.Close();
//                        return View("ContactForm");
//                    }
//                }
//            }


            return View();
        }
    }
}