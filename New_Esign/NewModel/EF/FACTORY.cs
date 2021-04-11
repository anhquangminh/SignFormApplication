

namespace NewModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class FACTORY
    {
        [Key]
        public long FactoryID { get; set; }

        public string Factory_name { get; set; }
    }
}
