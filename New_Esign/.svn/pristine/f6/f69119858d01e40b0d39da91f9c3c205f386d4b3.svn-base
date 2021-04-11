namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BU")]
    public partial class BU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BU()
        {
            Accounts = new HashSet<Account>();
            Approvers = new HashSet<Approver>();
        }

        public int BUID { get; set; }

        [Required]
        [StringLength(100)]
        public string BUName { get; set; }

        [Required]
        [StringLength(10)]
        public string SiteID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Approver> Approvers { get; set; }

        public virtual Site Site { get; set; }
    }
}
