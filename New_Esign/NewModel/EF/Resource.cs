namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resource
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string languageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string resourceName { get; set; }

        [Required]
        [StringLength(250)]
        public string resourceValue { get; set; }

        [StringLength(10)]
        public string type { get; set; }

        public virtual Language Language { get; set; }
    }
}
