using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Esign.Models
{
    public class LoginUserModel
    {

        [Required(ErrorMessage = "Mời nhập mã thẻ nhân viên")]
        [StringLength(50)]
        public string UserID { set; get; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        [StringLength(100)]
        public string PassWord { set; get; }

        public bool RememberMe { set; get; }
    }
}