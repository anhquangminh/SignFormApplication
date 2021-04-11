namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaterialOut_Apply_D_Temp
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string M_Desc { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(50)]
        public string Qty { get; set; }

        [StringLength(50)]
        public string Rec_Depart { get; set; }

        [StringLength(50)]
        public string LotCode { get; set; }
    }
}
