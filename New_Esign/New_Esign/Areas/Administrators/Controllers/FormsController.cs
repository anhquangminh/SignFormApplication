using New_Esign.Areas.Administrators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Areas.Administrators.Controllers
{
    public class FormsController : Controller
    {
        // GET: Administrators/Forms
        public ActionResult Index(FormsModel fm, int? page)
        {
            RepairFormsModel(fm, page);

            //For paging
            int totalRecord = fm.ListFormsModel.Count;
            int totalPage = totalRecord / PagerModel.PageSize;
            if (totalRecord % PagerModel.PageSize != 0) totalPage += 1;
            ViewBag.Pager = new PagerModel("Index", "Forms", "Administrators", (int)fm.CurentPage, totalPage);

            return View(fm);
        }

        public void RepairFormsModel(FormsModel fm, int? page)
        {
            if (fm == null) fm = new FormsModel();
            if (page == null) page = 1;
            if (fm.CurentPage == null) fm.CurentPage = page;
            //Get List Site
            string SelectedSite = fm.SelectedSite;
            fm.SiteSelector = EsignCommon.GetSelectListSite(ref SelectedSite,true);
            fm.SelectedSite = SelectedSite;
            //Get List BU
            string SelectedBU = fm.SelectedBU;
            fm.BUSelector = EsignCommon.GetSelectListBU(fm.SelectedSite, ref SelectedBU,true);
            fm.SelectedBU = SelectedBU;


        }

        public List<FormInfoModel> GetListForm(string site,string bu,string searchdata)
        {
            List<FormInfoModel> ListForm = new List<FormInfoModel>();

            return ListForm;
        }
    }
}