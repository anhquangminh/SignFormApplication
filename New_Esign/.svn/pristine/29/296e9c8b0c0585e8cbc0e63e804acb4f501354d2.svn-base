using New_Esign.Areas.Employee.Models;
using NewModel.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace New_Esign.Areas.Employee.Controllers
{
    public class UpfileController : Controller
    {
        private DBConnectData cn = new DBConnectData();
        // GET: Employee/Upfile
        public ActionResult FileUpload()
        {
            return View();
        }

        // upload files
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase files)
        {
            String FileExt = Path.GetExtension(files.FileName).ToUpper();
            if (FileExt == ".PDF")
            {
                Stream str = files.InputStream;
                BinaryReader Br = new BinaryReader(str);
                Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                FileDetailsModel Fd = new FileDetailsModel();
                Fd.FileName = files.FileName;
                Fd.FileContent = FileDet;
                SaveFileDetails(Fd);
                return RedirectToAction("FileUpload");
            }
            else
            {
                ViewBag.FileStatus = "Invalid file format.";
                return View();
            }
        }
        //dowload files
        [HttpGet]
        public FileResult DownloadFiles(int id)
        {
            List<FileDetailsModel> ObjFiles = GetFileList();
            var FileByID = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();
            return File(FileByID.FileContent, "application/pdf", FileByID.FileName);
        }
        // get file detail
        [HttpGet]
        public PartialViewResult FileDetails()
        {
            List<FileDetailsModel> DetList = GetFileList();
            return PartialView("FileDetails", DetList);
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
        private List<FileDetailsModel> GetFileList()
        {            
            var DetList = cn.Database.SqlQuery<FileDetailsModel>("GetFileDetails").ToList();
            return DetList;
        }    
        //private List<Application> GetFileListApp()
        //{
        //    try
        //    {
        //        var DetList = cn.Database.SqlQuery<Application>("GetFileApp2").ToList();
        //        return DetList;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //[HttpGet]
        //public PartialViewResult FileApp()
        //{
        //    List<Application> DetList = GetFileListApp();
        //    return PartialView("FileApp", DetList);
        //}
        //[HttpGet]
        //public FileResult DownloadFilesApp(int id)
        //{
        //    List<Application> ObjFiles = GetFileListApp();
        //    var FileByID = (from FC in ObjFiles
        //                    where FC.ApplicationNo.Equals(id)
        //                    select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();
        //    return File(FileByID.FileContent, "application/pdf", FileByID.FileName);
        //}
    }
}