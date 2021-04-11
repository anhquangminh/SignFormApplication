namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMODULEFUNCTION")]
    public partial class EMODULEFUNCTION
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(32)]
        public string MODULENAME { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(32)]
        public string SECTIONNAME { get; set; }

        [StringLength(100)]
        public string SECTIONNAME_EN { get; set; }

        public decimal? SECTIONSORTNO { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(32)]
        public string FUNCTIONNAME { get; set; }

        public decimal? SORTNO { get; set; }

        [StringLength(1)]
        public string Is_CJ { get; set; }

        public int? CJ_No { get; set; }

        [StringLength(50)]
        public string PROMPTNAME { get; set; }

        [StringLength(100)]
        public string PROMPTNAME_EN { get; set; }

        [StringLength(100)]
        public string DESCRIPTION { get; set; }

        [StringLength(20)]
        public string FUNCCATEGORY { get; set; }

        [StringLength(50)]
        public string FUNCFIGURE { get; set; }

        [StringLength(30)]
        public string FUNCVBFORM { get; set; }

        [StringLength(50)]
        public string FUNCDESC { get; set; }

        [StringLength(255)]
        public string WEBPAGE { get; set; }

        public decimal? NOTSHOW { get; set; }

        public decimal? NEWWINDOW { get; set; }

        [StringLength(20)]
        public string LUPBY { get; set; }

        public DateTime? LUPDATE { get; set; }
    }
}
