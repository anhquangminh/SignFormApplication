namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_History
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string User_Id { get; set; }

        [StringLength(50)]
        public string User_Name { get; set; }

        [StringLength(500)]
        public string Action_Desc { get; set; }

        [StringLength(50)]
        public string Computer_IP { get; set; }

        [StringLength(50)]
        public string Computer_Name { get; set; }

        [StringLength(50)]
        public string Computer_OS { get; set; }

        [StringLength(50)]
        public string Computer_IE { get; set; }

        [StringLength(100)]
        public string Action_Type { get; set; }

        public DateTime? Create_Date { get; set; }

        [StringLength(50)]
        public string Groupid { get; set; }

        [StringLength(50)]
        public string ServerIP { get; set; }

        public DateTime? LoginStartTime { get; set; }

        public DateTime? LoginEndTime { get; set; }
    }
}
