using System.Collections.Generic;
using System.Web.Mvc;

namespace New_Esign.Areas.Administrators.Models
{
    public class FormInfoModel
    {
        public int FormID { get; set; }
        public string FormName { get; set; }
        public string FormNameEN { get; set; }
        public string FormNameVI { get; set; }
        public string FormNameCH { get; set; }
        public string Department { get; set; }
        public string FormDisplayName { get; set; }
        public List<FormContentModel> FormContent { get; set; }
        public List<FormSignModel> FormSign { get; set; }
        public FormInfoModel()
        {
            this.FormID = 0;
            this.FormName = "";
            this.FormNameEN = "";
            this.FormNameVI = "";
            this.FormNameCH = "";
            this.Department = "";
            this.FormDisplayName = "";
            this.FormContent = new List<FormContentModel>();
            this.FormSign = new List<FormSignModel>();
        }
        public FormInfoModel(int _FormID, string _FormName, string _FormNameEN, string _FormNameVI, string _FormNameCH, string _Department, string _FormDisplayName, List<FormContentModel> _FormContents, List<FormSignModel> _FormSigns)
        {
            this.FormID = _FormID;
            this.FormName = _FormName;
            this.FormNameEN = _FormNameEN;
            this.FormNameVI = _FormNameVI;
            this.FormNameCH = _FormNameCH;
            this.Department = _Department;
            this.FormDisplayName = _FormDisplayName;
            this.FormContent = _FormContents;
            this.FormSign = _FormSigns;
        }
        public FormInfoModel(int _FormID, string _FormName, string _Department, string _FormDisplayName, List<FormContentModel> _FormContents, List<FormSignModel> _FormSigns)
        {
            this.FormID = _FormID;
            this.FormName = _FormName;
            this.FormDisplayName = _FormDisplayName;
            this.FormNameEN = LanguageHelper.GetResource(this.FormDisplayName, LanguageHelper.languageEN, true);
            this.FormNameVI = LanguageHelper.GetResource(this.FormDisplayName, LanguageHelper.languageVI, true);
            this.FormNameCH = LanguageHelper.GetResource(this.FormDisplayName, LanguageHelper.languageCH, true);
            this.Department = _Department;
            this.FormContent = _FormContents;
            this.FormSign = _FormSigns;
        }
    }

    public class FormsModel
    {
        public FormsModel()
        {
            CurentPage = 1;
            ListFormsModel = new List<FormInfoModel>();
        }
        public FormsModel(string searchData, int? curentPage, List<FormInfoModel> listFormInfoModel)
        {
            SearchData = searchData;
            CurentPage = curentPage;
            ListFormsModel = listFormInfoModel;
        }

        public string SearchData { get; set; }
        public int? CurentPage { get; set; }
        public List<FormInfoModel> ListFormsModel { get; set; }
        public SelectList SiteSelector { get; set; }
        public string SelectedSite { get; set; }
        public SelectList BUSelector { get; set; }
        public string SelectedBU { get; set; }
        public string DeleteFormsId { get; set; }

    }
}