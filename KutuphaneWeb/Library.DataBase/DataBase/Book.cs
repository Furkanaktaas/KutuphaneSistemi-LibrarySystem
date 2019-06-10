namespace Library.DataBase.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Loans = new HashSet<Loan>();
            Reserves = new HashSet<Reserve>();
        }

        public int bookID { get; set; }

        [MaxLength(50, ErrorMessage = "Kitap Adý 50 karakterden fazla olamaz"),
         MinLength(1, ErrorMessage = "Kitap Adý 1 karakterden az olamaz"),
         Required(ErrorMessage = "Kitap Adý alaný boþ geçilemez")]
        public string name { get; set; }

        [MaxLength(50, ErrorMessage = "Yazar Adý 50 karakterden fazla olamaz"),
         MinLength(3, ErrorMessage = "Yazar Adý 3 karakterden az olamaz"),
         Required(ErrorMessage = "Yazar Adý alaný boþ geçilemez")]
        public string writer { get; set; }

        [MaxLength(50, ErrorMessage = "Yayýn Evi 50 karakterden fazla olamaz"),
         MinLength(3, ErrorMessage = "Yayýn Evi 3 karakterden az olamaz"),
         Required(ErrorMessage = "Yayýn Evi alaný boþ geçilemez")]
        public string publisher { get; set; }

        [Required(ErrorMessage = "Sayfa Sayýsý alaný boþ geçilemez")]
        public int? numberOfPages { get; set; }

        public int? statusID { get; set; }

        public int? categoryID { get; set; }

        [StringLength(50)]
        public string imageName { get; set; }

        public virtual Category Category { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
