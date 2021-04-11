using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Esign.Areas.Employee.Models
{
    public class ITRequestModel
    {
        public long ID { get; set; }

        
        public string AppNo { get; set; }

        //[Required]
        public string EmpNo { get; set; }

        //[Required]
        public string Name { get; set; }

        [Required(ErrorMessage= "分機 必要填寫的 - Số điện thoại không được để trống ")]
        public string NumPhone { get; set; }

        //[Required]
        public string Site { get; set; }

        //[Required]
        public string BU { get; set; }

        //[Required]
        public string Depart { get; set; }

        [Required]
       // [EmailAddress(ErrorMessage = "電子郵件不正確，請重新輸入-Mail không đúng vui lòng nhập lại ")]
        public string Mail { get; set; }

        [Required]
        public string CodeCost { get; set; }

        [Required(ErrorMessage = "廠區 必要填寫的- Xưởng không được để trống")]
        public string OfficeFac { get; set; }

        //[Required]
        public string Location { get; set; }

        //[Required]
        public string OfficeFloor { get; set; }

        [Required]
        [StringLength(17, ErrorMessage = "格式錯誤 - Lỗi định dạng", MinimumLength = 17)]
        public string MacAd { get; set; }

        //[Required]
        public string ComputerSpeci { get; set; }

        //[Required]
        public string ComputerBrand { get; set; }

       // [Required(ErrorMessage = "電腦類型 必要填寫的 -Loại máy tính không được để trống")]
        public string KindofPC { get; set; }

        public bool desktop { get; set; }

        public bool laptop { get; set; }

       // [Required(ErrorMessage = "資產代碼 必要填寫的 -Mã tài sản không được để trống")]
        public string AssetCode { get; set; }

       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TimeStart { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TimeEnd { get; set; }
        
        [Required(ErrorMessage = "單型 代碼 必要填寫的- Loại đơn không được để trống ")]
        public string ApplicationType { get; set; }

        public string ComputerName { get; set; }

        
        public string IPAdd { get; set; }

        public string SeriNum { get; set; }

        public string ColorPC { get; set; }

        public string LocationApply { get; set; }

        public string USB_read { get; set; }

        public string USB_Write { get; set; }



        [Required(ErrorMessage = "理由 必要填寫的-Lý do xin đơn không được để trống")]
        [StringLength(4000)]
        public string Reason { get; set; }

        public string USB { get; set; }

        public string AdminAc { get; set; }

        public string Port { get; set; }

        public string YellowCard { get; set; }

        public string OpenAccess { get; set; }

        public string fileName { get; set; }

        public string filePath { get; set; }

        public string factoryApply { get; set; }

        public string locationMulti { get; set; }

        public List<ApprovalAppModel> approvalApps { get; set; }
    }
}