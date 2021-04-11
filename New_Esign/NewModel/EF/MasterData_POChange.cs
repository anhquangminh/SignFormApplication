namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MasterData_POChange
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string F_Site { get; set; }

        [StringLength(50)]
        public string BU { get; set; }

        [StringLength(50)]
        public string Plant { get; set; }

        [StringLength(150)]
        public string ChangeType { get; set; }

        [StringLength(150)]
        public string WOCurrentStatus { get; set; }

        [StringLength(50)]
        public string RespDep { get; set; }

        [StringLength(50)]
        public string Submit_person { get; set; }

        public DateTime? Submit_Time { get; set; }

        [StringLength(50)]
        public string Lastedit_Person { get; set; }

        public DateTime? Lastedit_Time { get; set; }
    }
}
