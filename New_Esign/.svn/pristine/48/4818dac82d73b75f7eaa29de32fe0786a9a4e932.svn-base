namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(30)]
        public string UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        [StringLength(15)]
        public string CostNo { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        public int? BUID { get; set; }

        [StringLength(10)]
        public string SiteID { get; set; }

        [StringLength(50)]
        public string ManagerName { get; set; }

        [StringLength(20)]
        public string ManagerEmpNo { get; set; }

        [StringLength(100)]
        public string ManagerEmail { get; set; }

        [Column(TypeName = "ntext")]
        public string Purpose { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        [StringLength(100)]
        public string Permission { get; set; }

        public bool IsActive { get; set; }

        public virtual BU BU { get; set; }

        public virtual Site Site { get; set; }
    }
}
