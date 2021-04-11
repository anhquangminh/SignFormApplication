namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MasterData_Sign
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string DFSite { get; set; }

        [StringLength(50)]
        public string Building { get; set; }

        [StringLength(50)]
        public string Floor { get; set; }

        [StringLength(50)]
        public string BU { get; set; }

        [StringLength(50)]
        public string FormType { get; set; }

        [StringLength(50)]
        public string F_empno { get; set; }

        [StringLength(50)]
        public string F_Name { get; set; }

        [StringLength(50)]
        public string PowerLeave { get; set; }

        public DateTime? Lasteditdt { get; set; }

        [StringLength(50)]
        public string Lasteditby { get; set; }
    }
}
