namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assign_Info
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ModuleName { get; set; }

        [StringLength(50)]
        public string ApplyNO { get; set; }

        public DateTime? Sign_Date { get; set; }

        [StringLength(200)]
        public string Signer { get; set; }

        [StringLength(50)]
        public string Signer_Type { get; set; }

        [StringLength(100)]
        public string Agent { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string Is_Deliver { get; set; }

        [StringLength(50)]
        public string Deliver_Person { get; set; }

        [StringLength(50)]
        public string back_person { get; set; }

        [StringLength(50)]
        public string back_type { get; set; }

        [StringLength(500)]
        public string actionitem { get; set; }

        [StringLength(50)]
        public string SortNum { get; set; }

        [StringLength(150)]
        public string respdep { get; set; }
    }
}
