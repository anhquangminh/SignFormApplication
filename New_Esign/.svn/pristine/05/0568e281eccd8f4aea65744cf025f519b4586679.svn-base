namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Form
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Form()
        {
            FormContents = new HashSet<FormContent>();
            FormSigns = new HashSet<FormSign>();
        }

        public int FormID { get; set; }

        [Required]
        [StringLength(50)]
        public string FormName { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        [StringLength(200)]
        public string FormDisplayName { get; set; }

        [StringLength(10)]
        public string Site { get; set; }

        public int? BusinessUnitID { get; set; }

        [StringLength(10)]
        public string Creator { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormContent> FormContents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormSign> FormSigns { get; set; }
    }
}
