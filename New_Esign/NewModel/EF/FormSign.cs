namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormSign")]
    public partial class FormSign
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FormID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SignStep { get; set; }

        [StringLength(30)]
        public string SignUser { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string SignDescription { get; set; }

        public virtual Form Form { get; set; }
    }
}
