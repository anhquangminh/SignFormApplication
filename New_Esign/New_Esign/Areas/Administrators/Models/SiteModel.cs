using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New_Esign.Areas.Administrators.Models
{
    public class SiteModel
    {
        public SiteModel(string siteID, string siteName)
        {
            SiteID = siteID;
            SiteName = siteName;
        }

        public string SiteID { get; set; }
        public string SiteName { get; set; }
    }
}