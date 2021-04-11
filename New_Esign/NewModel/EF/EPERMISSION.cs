namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EPERMISSION")]
    public partial class EPERMISSION
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string PERMISSIONTYPE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(32)]
        public string PERMISSIONNAME { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(32)]
        public string FUNCTIONNAME { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal MODIFICATION { get; set; }

        [StringLength(20)]
        public string LUPBY { get; set; }

        public DateTime? LUPDATE { get; set; }

        [StringLength(50)]
        public string Authority { get; set; }
    }
}
