using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New_Esign.Areas.Employee.Models
{
    public class SigningMenuModel
    {
        public string AppNo { get; set; }

        public string signEmpNo { get; set; }

        public string SignName { get; set; }

        public string statusName { get; set; }

        public int? step { get; set; }

        public string signOver { get; set; }

        public string fowardInfo { get; set; }
    }
}