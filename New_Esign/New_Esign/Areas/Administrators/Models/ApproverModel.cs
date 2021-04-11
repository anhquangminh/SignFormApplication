using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using New_Esign.Areas.Employee.Models;
using NewModel.EF;

namespace New_Esign.Areas.Administrators.Models
{
    public class ApproverModel
    {
        public ApproverModel()
        {

        }
        public ApproverModel(string approverID, string siteId, string bUID, string buName, string approverType, string approverEmpNo, string approverEmpName, string setupName, string setupTime)
        {
            ApproverID = approverID;
            SiteId = siteId;
            BUID = bUID;
            BuName = buName;
            ApproverType = approverType;
            ApproverEmpNo = approverEmpNo;
            ApproverEmpName = approverEmpName;
            SetupName = setupName;
            SetupTime = setupTime;
        }
        public string ApproverID { get; set; }
        public string SiteId { get; set; }
        public string BUID { get; set; } //Business Unit
        public string BuName { get; set; }
        public string ApproverType { get; set; }
        [Required]
        public string ApproverEmpNo { get; set; }
        [Required]
        public string ApproverEmpName { get; set; }
        public string SetupName { get; set; }
        public string SetupTime { get; set; }

    }
    //19035876908017
    public class ApproverManagerModel
    {
        public ApproverManagerModel()
        {

        }
        public ApproverManagerModel(string searchData, int? curentPage, List<ApproverModel> listApproverModel)
        {
            SearchData = searchData;
            CurentPage = curentPage;
            ListApproverModel = listApproverModel;
        }

        public string SearchData { get; set; }
        public int? CurentPage { get; set; }
        public List<ApproverModel> ListApproverModel { get; set; }
        public string DeleteApproverId { get; set; }
    }

    public class ApproverDetailModel
    {
        public ApproverModel ApproverModel { get; set; }
        public SelectList TypeSelector { get; set; }
        public SelectList SiteSelector { get; set; }
        public SelectList BUSelector { get; set; }
        public string SelectedSite { get; set; }
        public string SelectedBU { get; set; }
        public string SelectedType { get; set; }
    }

    public class ApprovalApp
    {
        public EmpModel EmpModels { get; set; }
        public List<APPROVE_SIGN> APPROVEs { get; set; }
        public string NoteApproval { get; set; }
        
    }
}