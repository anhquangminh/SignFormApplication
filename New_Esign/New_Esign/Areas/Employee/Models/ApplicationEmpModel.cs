using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NewModel.EF;

namespace New_Esign.Areas.Employee.Models
{
    public class ApplicationEmpModel
    {
        [Key]
        public long APPID { get; set; }

        [StringLength(50)]
        public string APPNO { get; set; }

        [StringLength(100)]
        public string APPSTATUS { get; set; }

        [StringLength(50)]
        public string CHECKWAIT { get; set; }

        [StringLength(50)]
        public string APPSTATES { get; set; }

        [StringLength(50)]
        public string USEREMP { get; set; }

        [StringLength(50)]
        public string COSTCODE { get; set; }

        [StringLength(500)]
        public string USERDEPARTMENT { get; set; }

        [StringLength(100)]
        public string USERNAME { get; set; }

        [StringLength(200)]
        public string USERMAIL { get; set; }

        [StringLength(50)]
        public string USERPHONE { get; set; }

        [StringLength(50)]
        public string FACTORY { get; set; }

        [StringLength(50)]
        public string PRIORITY { get; set; }

        [StringLength(3000)]
        public string APPREASON { get; set; }

        [StringLength(100)]
        public string REQUIREDDEPARTMENT { get; set; }

        [StringLength(50)]
        public string CODEWORKSID { get; set; }

        [StringLength(1000)]
        public string APPTYPE { get; set; }

        [StringLength(50)]
        public string CHECKWAITNAME { get; set; }

        [StringLength(50)]
        public string ATTACHFILENAME { get; set; }

        [StringLength(50)]
        public string ATTACHFILENAME1 { get; set; }

        [StringLength(50)]
        public string DOU { get; set; }

        public int? BUID { get; set; }

        [StringLength(50)]
        public string SiteID { get; set; }

        public DateTime TIMECREATE { get; set; }

        public int? curentPage { get; set; }

        [Display(Name = "Uploaded File")]
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        
        [DataType(DataType.Upload)]
        [Display(Name = "Select File")]
        public HttpPostedFileBase files { get; set; }

        //public List<APPROVE_SIGN> aPPROVE_SIGNs { get; set; }

        //public ApplicationEmpModel()
        //{            
        //    this.aPPROVE_SIGNs = new List<APPROVE_SIGN>();
        //}
    }
}