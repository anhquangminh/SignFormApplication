using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New_Esign.Areas.Administrators.Models
{
    public class BusinessUnitModel
    {
        public BusinessUnitModel(string bUID, string bUName)
        {
            BUID = bUID;
            BUName = bUName;
        }

        public string BUID { get; set; }
        public string BUName { get; set; }
    }
}