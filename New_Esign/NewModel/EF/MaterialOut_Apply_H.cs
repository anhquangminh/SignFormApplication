namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaterialOut_Apply_H
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ApplyNO { get; set; }

        [StringLength(50)]
        public string DFSite { get; set; }

        [StringLength(50)]
        public string ApplyType { get; set; }

        [StringLength(50)]
        public string Division { get; set; }

        [StringLength(50)]
        public string ApplyDept { get; set; }

        [StringLength(50)]
        public string ApplyPerson { get; set; }

        [StringLength(50)]
        public string Emp_no { get; set; }

        public DateTime? ApplyDate { get; set; }

        [StringLength(200)]
        public string Ext { get; set; }

        public DateTime? VisitDate { get; set; }

        [StringLength(10)]
        public string VisitTimeFrom { get; set; }

        [StringLength(10)]
        public string VisitTimeTO { get; set; }

        [StringLength(50)]
        public string ShipType { get; set; }

        [StringLength(50)]
        public string Person_Empno { get; set; }

        [StringLength(50)]
        public string PersonName { get; set; }

        [StringLength(50)]
        public string TruckSize { get; set; }

        [StringLength(50)]
        public string MLnumber_plate { get; set; }

        [StringLength(50)]
        public string OtherTool { get; set; }

        [StringLength(50)]
        public string Manager { get; set; }

        [StringLength(50)]
        public string Manager_NO { get; set; }

        [StringLength(50)]
        public string Boss { get; set; }

        [StringLength(50)]
        public string Boss_NO { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime? submit_time { get; set; }

        [StringLength(50)]
        public string SUbmit_person { get; set; }

        public DateTime? Lastedit_time { get; set; }

        [StringLength(50)]
        public string LastEdit_person { get; set; }

        [StringLength(50)]
        public string Security_Guard_NO { get; set; }

        [StringLength(100)]
        public string AttachFileName { get; set; }
    }
}
