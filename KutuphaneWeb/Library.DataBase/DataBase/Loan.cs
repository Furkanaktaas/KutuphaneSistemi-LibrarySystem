namespace Library.DataBase.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loan")]
    public partial class Loan
    {
        public int loanID { get; set; }

        public int? userID { get; set; }

        public int? bookID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateIssue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateReturn { get; set; }

        public virtual Book Book { get; set; }

        public virtual User User { get; set; }
    }
}
