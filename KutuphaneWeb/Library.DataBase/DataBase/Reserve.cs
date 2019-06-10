namespace Library.DataBase.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reserve")]
    public partial class Reserve
    {
        public int reserveID { get; set; }

        public int? userID { get; set; }

        public int? bookID { get; set; }

        public virtual Book Book { get; set; }

        public virtual User User { get; set; }
    }
}
