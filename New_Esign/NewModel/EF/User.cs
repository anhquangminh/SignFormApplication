namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [StringLength(100)]
        public string DFSite { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string PassWord { get; set; }

        [StringLength(50)]
        public string Dept { get; set; }

        [StringLength(50)]
        public string Emp_NO { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string mailbox { get; set; }

        [StringLength(100)]
        public string division { get; set; }

        [StringLength(50)]
        public string CostNO { get; set; }

        [StringLength(100)]
        public string purpose { get; set; }

        public DateTime? Apply_Time { get; set; }

        [StringLength(10)]
        public string IsConfirm { get; set; }

        public DateTime? LastLog_Time { get; set; }

        public int? Fail_Times { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(50)]
        public string LockStatus { get; set; }

        public DateTime? PWDModifyDate { get; set; }

        [StringLength(50)]
        public string PassWord1 { get; set; }
    }
}
