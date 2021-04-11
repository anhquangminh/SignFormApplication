using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Esign.Areas.Employee.Models
{
    public class ApplicationContentModel
    {
        public string AppNo { get; set; }

        [StringLength(2000)]
        public string AppTitle { get; set; }

        [StringLength(4000)]
        public string AppContent { get; set; }

        [Required]
        public int? FormID { get; set; }

        public int? AppStep { get; set; }

        [StringLength(4000)]
        public string FormContent { get; set; }

    }
}