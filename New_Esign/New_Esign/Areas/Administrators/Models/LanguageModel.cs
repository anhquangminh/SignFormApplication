using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Areas.Administrators.Models
{
    public class LanguageModel
    {
        public string languageID { get; set; }
        public string languageName { get; set; }
        public string languageIcon { get; set; }

        public List<ResourceModel> listResource { get; set; }

        public LanguageModel()
        {
            this.languageID = this.languageName = this.languageIcon = "";
        }
        public LanguageModel(string _langId, string _langName, string _langIcon)
        {
            this.languageID = _langId;
            this.languageName = _langName;
            this.languageIcon = _langIcon;
        }

        public IEnumerable<SelectListItem> Languages { get; set; }
        public int SelectedLanguageId { get; set; }
    }
}