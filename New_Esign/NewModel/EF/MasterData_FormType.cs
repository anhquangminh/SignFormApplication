namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MasterData_FormType
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string FormType { get; set; }

        [StringLength(50)]
        public string DFSite { get; set; }

        [StringLength(50)]
        public string ApplyType { get; set; }

        [StringLength(50)]
        public string Security_Guard_NO { get; set; }

        [StringLength(1)]
        public string IsValid { get; set; }

        [StringLength(1)]
        public string IsManageNo { get; set; }
    }
}
