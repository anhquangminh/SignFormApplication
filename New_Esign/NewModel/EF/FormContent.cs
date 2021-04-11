namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormContent")]
    public partial class FormContent
    {
        public int FormContentID { get; set; }

        public int? FormID { get; set; }

        [StringLength(50)]
        public string InputName { get; set; }

        [StringLength(20)]
        public string InputType { get; set; }

        public int? InputIndex { get; set; }

        public bool? IsRequired { get; set; }

        [StringLength(200)]
        public string Data { get; set; }

        public virtual Form Form { get; set; }
    }
}
