namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubmitSign")]
    public partial class SubmitSign
    {
        public long submitSignID { get; set; }

        public int? FormID { get; set; }

        public int? SignNo { get; set; }

        [StringLength(500)]
        public string SignName { get; set; }

        [StringLength(50)]
        public string state { get; set; }
    }
}
