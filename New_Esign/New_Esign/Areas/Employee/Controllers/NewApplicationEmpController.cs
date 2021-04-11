using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New_Esign.Areas.Employee.Models;
using NewModel.EF;

namespace New_Esign.Areas.Employee.Controllers
{
    public class NewApplicationEmpController : Controller
    {
        private DBConnectData cn = new DBConnectData();
        // GET: Employee/NewApplicationEmp
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationEmpModel appEmp, HttpPostedFileBase files)
        {
            

            if(files != null)
            {
                String FileExt = Path.GetExtension(files.FileName).ToUpper();
                if (FileExt == ".PDF" || FileExt == ".XLSX")
                {
                    Stream str = files.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    appEmp.FileName = files.FileName;
                    appEmp.FileContent = FileDet;
                    appEmp.TIMECREATE = DateTime.Now;
                    CreateApplication(appEmp);
                    return View();
                }
                else
                {
                    ViewBag.FileStatus = "Invalid file format.";
                    return View();
                }
            }
            else
            {
                return View("Index");
            }
            
        }

        private void SaveFileDetails(FileDetailsModel objDet)
        {

            object[] parameters =
            {
                 new SqlParameter("FileName", objDet.FileName),
                 new SqlParameter("FileContent", objDet.FileContent),
            };

            cn.Database.ExecuteSqlCommand("AddFileDetails @FileName,@FileContent", parameters);
        }
        public void CreateApplication(ApplicationEmpModel am)
        {
            if (am != null)
            {
                try
                {
                    SQLServerDBHelper db = new SQLServerDBHelper("ESignDB");

                    string InsertSQL = @"INSERT INTO Application(ApplicationNo, Username, Email, Timecreate, status,FileName,FileContent) VALUES(@APPID,@USERNAME,@USERMAIL,@TIMECREATE,@APPSTATUS,@FileName,@FileContent)";
                    SqlParameter[] parameters = new SqlParameter[7];
                    parameters.SetValue(new SqlParameter("APPID", am.APPID), 0);
                    parameters.SetValue(new SqlParameter("USERNAME", am.USERNAME), 1);
                    parameters.SetValue(new SqlParameter("USERMAIL", am.USERMAIL), 2);
                    parameters.SetValue(new SqlParameter("TIMECREATE", am.TIMECREATE), 3);
                    parameters.SetValue(new SqlParameter("APPSTATUS", am.APPSTATUS), 4);
                    parameters.SetValue(new SqlParameter("FileName", am.FileName), 5);
                    parameters.SetValue(new SqlParameter("FileContent", am.FileContent), 6);                    
                    db.ExcuteNonQuery(InsertSQL, parameters);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                //if (db.ExcuteNonQuery(InsertSQL))
                //    Ultils.WriteCookie("Success", LanguageHelper.GetResource("AddSuccess"));
                //else
                //    Ultils.WriteCookie("Error", LanguageHelper.GetResource("AddFail"));
            }
            else
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("ApproverUpdateEmpty"));
            }

        }
        private List<Application> GetFileListApp()
        {
            var DetList = cn.Database.SqlQuery<Application>("GetFileApp").ToList();
            return DetList;
        }
        [HttpGet]
        public PartialViewResult FileApp()
        {
            List<Application> DetList = GetFileListApp();
            return PartialView("FileApp", DetList);
        }

        //dowload
        [HttpGet]
        public FileResult DownloadFilesApp(int id)
        {
            //List<Application> ObjFiles = GetFileListApp();
            //var FileByID = (from FC in ObjFiles
            //                where FC.ApplicationNo.Equals(id)
            //                select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();

            //return File(FileByID.FileContent, "application/pdf", FileByID.FileName);
            try
            {
                List<Application> ObjFiles = GetFileListApp();
                var FileByID = (from FC in ObjFiles
                                where FC.ApplicationNo == id
                                select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();
                return File(FileByID.FileContent, "application/pdf", FileByID.FileName);
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
    }
}