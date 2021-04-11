namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Language
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Language()
        {
            Resources = new HashSet<Resource>();
        }

        [StringLength(10)]
        public string languageId { get; set; }

        [Required]
        [StringLength(50)]
        public string languageName { get; set; }

        [Column(TypeName = "ntext")]
        public string languageIcon { get; set; }

        public virtual Language Languages1 { get; set; }

        public virtual Language Language1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
