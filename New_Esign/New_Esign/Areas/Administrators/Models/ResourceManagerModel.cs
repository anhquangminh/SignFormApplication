using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_Esign.Areas.Administrators.Models
{
    public class ResourceManagerModel
    {
        public string Language { get; set; }
        public IEnumerable<SelectListItem> listLanguage { get; set; }
        public List<ResourceModel> listResource { get; set; }

        public bool invalidModel { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Resource Name")]
        public string ResourceName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Resource Value")]
        public string ResourceValue { get; set; }

        public int? curentPage { get; set; }
        public ResourceManagerModel()
        {
            invalidModel = false;
            listLanguage = new List<SelectListItem>();
            this.listResource = new List<ResourceModel>();
        }
    }
}