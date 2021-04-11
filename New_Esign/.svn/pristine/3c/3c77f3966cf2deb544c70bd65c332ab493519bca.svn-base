namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Approver")]
    public partial class Approver
    {
        public int ApproverID { get; set; }

        [Required]
        [StringLength(10)]
        public string SiteID { get; set; }

        public int BUID { get; set; }

        [Required]
        [StringLength(100)]
        public string ApproverType { get; set; }

        [Required]
        [StringLength(20)]
        public string ApproverEmpNo { get; set; }

        [Required]
        [StringLength(50)]
        public string ApproverEmpName { get; set; }

        [StringLength(50)]
        public string SetupEmp { get; set; }

        public DateTime? SetupTime { get; set; }

        [StringLength(50)]
        public string LevelApprover { get; set; }

        public virtual BU BU { get; set; }

        public virtual Site Site { get; set; }
    }
}
