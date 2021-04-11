namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterData")]
    public partial class MasterData
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string DFSite { get; set; }

        [StringLength(50)]
        public string Division { get; set; }

        [StringLength(50)]
        public string Building { get; set; }

        [StringLength(800)]
        public string Security_Guard_NO { get; set; }
    }
}
