namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ApplicationNo { get; set; }

        [StringLength(50)]
        public string OrderNo { get; set; }

        public int? FormID { get; set; }

        [StringLength(30)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(10)]
        public string SiteID { get; set; }

        public int? BUID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        [StringLength(10)]
        public string DOU { get; set; }

        public DateTime? Timecreate { get; set; }

        [StringLength(200)]
        public string status { get; set; }

        [StringLength(10)]
        public string states { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpload { get; set; }

        [StringLength(100)]
        public string CodeCost { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        public byte[] FileContent { get; set; }

        [StringLength(200)]
        public string FileName2 { get; set; }

        public byte[] FileContent2 { get; set; }
    }
}
