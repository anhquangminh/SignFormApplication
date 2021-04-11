using New_Esign.Areas.Administrators.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Areas.Administrators.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: Administrators/Resources
        public ActionResult Index(ResourceManagerModel getRMM, int? page)
        {
            ResourceManagerModel rmm = new ResourceManagerModel();
            if (ViewBag.ResourceManagerModel != null)
            {
                getRMM = (ResourceManagerModel)ViewBag.ResourceManagerModel;
                ViewBag.ResourceManagerModel = null;
            }

            if (getRMM != null && getRMM.Language != null) Ultils.WriteCookie("RMMSelectedLang", getRMM.Language);
            rmm = repairResourceManagerModel(page);
            return View(rmm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ResourceManagerModel rmm)
        {
            int page = (int)rmm.curentPage;
            if (!ModelState.IsValid)
            {
                rmm = repairResourceManagerModel(page);
                rmm.invalidModel = true;
                ViewBag.ResourceManagerModel = rmm;
                return View(rmm);
            }
            AddResource(rmm.Language, rmm.ResourceName, rmm.ResourceValue);
            return RedirectToAction("Index", "Resources", new { area = "Administrators", page = page });
        }

        [HttpPost]
        public ActionResult Edit(ResourceManagerModel rmm)
        {
            int page = (int)rmm.curentPage;
            string langId = rmm.Language;
            string resourceName = rmm.ResourceName;
            string resourceValue = rmm.ResourceValue;
            if (string.IsNullOrWhiteSpace(langId) || string.IsNullOrWhiteSpace(resourceName) || string.IsNullOrWhiteSpace(resourceValue))
            {
                rmm = repairResourceManagerModel(page);
            }
            else
            {
                UpdateResource(langId, resourceName, resourceValue);
            }
            ViewBag.ResourceManagerModel = rmm;
            return RedirectToAction("Index", "Resources", new { area = "Administrators", page = page });
        }

        [HttpPost]
        public ActionResult Delete(ResourceManagerModel rmm)
        {
            int page = (int)rmm.curentPage;
            string langId = rmm.Language;
            string resourceName = rmm.ResourceName;
            if (string.IsNullOrWhiteSpace(langId) || string.IsNullOrWhiteSpace(resourceName))
            {
                rmm = repairResourceManagerModel(page);
            }
            else
            {
                DeleteResource(langId, resourceName);
            }
            ViewBag.ResourceManagerModel = rmm;
            return RedirectToAction("Index", "Resources", new { area = "Administrators", page = page });
        }

        public ResourceManagerModel repairResourceManagerModel(int? page)
        {
            ResourceManagerModel rmm = new ResourceManagerModel();
            if (Ultils.GetCookie("RMMSelectedLang") != null) rmm.Language = Ultils.GetCookie("RMMSelectedLang");
            List<SelectListItem> slm = new List<SelectListItem>();
            DataTable dtLanguage = LanguageHelper.GetListLanguage();
            foreach (DataRow dr in dtLanguage.Rows)
            {
                try
                {
                    slm.Add(new SelectListItem { Value = dr["languageId"].ToString().Trim(), Text = LanguageHelper.GetResource(dr["languageId"].ToString()) });
                    if (string.IsNullOrEmpty(rmm.Language)) rmm.Language = dr["languageId"].ToString().Trim();
                }
                catch (Exception exc) { }
            }
            rmm.listLanguage = slm;

            //For paging
            int totalRecord = getTotalRecord(rmm.Language);
            int totalPage = totalRecord / PagerModel.PageSize;
            if (totalRecord % PagerModel.PageSize != 0) totalPage += 1;
            ViewBag.Pager = new PagerModel("Index", "Resources", "Administrators", page == null ? 1 : (int)page, totalPage);

            if (page == null) page = 1;
            rmm.curentPage = page;
            rmm.listResource = getListResourceModel(rmm.Language, page, PagerModel.PageSize);

            return rmm;
        }

        #region Get List
        public List<ResourceModel> getListResourceModel(string languageId, int? page = null, int? pageSize = null)
        {
            List<ResourceModel> listResource = new List<ResourceModel>();

            DataTable dt = new DataTable();
            if (page != null && pageSize != null)
            {
                int start = (int)pageSize * ((int)page - 1);
                dt = getListResource(languageId, start, (int)pageSize);
            }
            else
            {
                dt = getListResource(languageId);
            }

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    ResourceModel rm = new ResourceModel();
                    rm.languageID = dr["languageId"].ToString(); 
                    rm.resourceName = dr["resourceName"].ToString();
                    rm.resourceValue = dr["resourceValue"].ToString();
                    listResource.Add(rm);
                }
                catch (Exception exc)
                {

                }
            }

            return listResource;
        }


        public int getTotalRecord(string _languageId)
        {
            int total = 0;
            string tempStr = "SELECT count(*) FROM Resources WHERE languageId='" + _languageId + "'";
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string value = db.GetSingleValueSelect(tempStr);
            try { total = Int16.Parse(value); } catch (Exception exc) { }
            return total;
        }
        public DataTable getListResource(string _languageId)
        {
            DataTable dt = new DataTable();
            string tempStr = "SELECT * FROM Resources WHERE languageId='" + _languageId + "'";
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            dt = db.DoSQLSelect(tempStr);
            return dt;
        }
        public DataTable getListResource(string _languageId, int _start, int _pageSize)
        {
            DataTable dt = new DataTable();
            string tempStr = "SELECT * FROM Resources WHERE languageId='" + _languageId + "'";
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            dt = db.DoSQLSelect(tempStr, _start, _pageSize);
            return dt;
        }
        #endregion

        #region Add/Update
        public bool IsExistResource(string _languageId, string _resourceName)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string checkSql = "SELECT * FROM Resources WHERE languageId='" + _languageId.Trim() + "' AND resourceName='" + _resourceName.Trim() + "'";
            DataTable dt = db.DoSQLSelect(checkSql);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }
        public bool AddResource(string _languageId, string _resourceName, string _resourceValue)
        {
            if (IsExistResource(_languageId, _resourceName))
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("Admin.Resource.Exist") + "[" + _resourceName + "= " + LanguageHelper.GetResource(_resourceName, _languageId) + "]");
            }
            else
            {
                try
                {
                    SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                    string insertSql = "INSERT INTO Resources(languageId,resourceName,resourceValue) VALUES('" + _languageId.Trim() + "',N'" + _resourceName.Trim() + "',N'" + _resourceValue.Trim() + "')";
                    if (db.ExcuteNonQuery(insertSql))
                    {
                        Ultils.WriteCookie("Success", LanguageHelper.GetResource("AddSuccess"));
                        return true;
                    }
                    else
                    {
                        Ultils.WriteCookie("Error", LanguageHelper.GetResource("AddFail"));
                    }
                }
                catch (Exception exc)
                {
                    Ultils.WriteCookie("Error", LanguageHelper.GetResource("Exception") + " >>>" + exc.Message);
                }
            }
            return false;
        }

        public bool UpdateResource(string _languageId, string _resourceName, string _resourceValue)
        {
            try
            {
                if (IsExistResource(_languageId, _resourceName))
                {
                    SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
                    string updateSql = "UPDATE Resources SET resourceValue=N'" + _resourceValue.Trim() + "' WHERE resourceName='" + _resourceName.Trim() + "' AND languageId='" + _languageId.Trim() + "'";
                    if (db.ExcuteNonQuery(updateSql))
                    {
                        Ultils.WriteCookie("Success", LanguageHelper.GetResource("UpdateSuccess"));
                        return true;
                    }
                    else
                    {
                        Ultils.WriteCookie("Error", LanguageHelper.GetResource("UpdateFail"));
                    }
                }
                else
                {
                    return AddResource(_languageId, _resourceName, _resourceValue);
                }

            }
            catch (Exception exc)
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("Exception") + " >>>" + exc.Message);
            }
            return false;
        }
        public bool DeleteResource(string _languageId, string _resourceName)
        {
            SQLServerDBHelper db = new SQLServerDBHelper("EsignDB");
            string deleteSql = "DELETE Resources WHERE resourceName='" + _resourceName.Trim() + "' AND languageId='" + _languageId.Trim() + "'";
            if (db.ExcuteNonQuery(deleteSql))
            {
                Ultils.WriteCookie("Success", LanguageHelper.GetResource("DeleteSuccess"));
                return true;
            }
            else
            {
                Ultils.WriteCookie("Error", LanguageHelper.GetResource("DeleteFail"));
            }
            return false;
        }
        #endregion
    }
}