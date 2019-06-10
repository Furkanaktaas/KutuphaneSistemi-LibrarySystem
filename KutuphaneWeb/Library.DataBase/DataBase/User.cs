    namespace Library.DataBase.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Loans = new HashSet<Loan>();
            Reserves = new HashSet<Reserve>();
        }

        public int userID { get; set; }

        [MaxLength(50, ErrorMessage = "Adýnýz 50 karakterden fazla olamaz"),
         MinLength(3, ErrorMessage = "Ad 3 karakterden az olamaz"),
         Required(ErrorMessage = "Ad alaný boþ geçilemez")]
        public string name { get; set; }

        [StringLength(50, ErrorMessage = "Soyadýnýz 50 karakterden fazla olamaz"),
         MinLength(2, ErrorMessage = "Soyad 2 karakterden az olamaz"),
         Required(ErrorMessage = "Soyad alaný boþ geçilemez")]
        public string surname { get; set; }

        [StringLength(11, ErrorMessage = "Telefon 11 karakterden fazla olamaz"),
         MinLength(11, ErrorMessage = "Telefon 11 karakterden az olamaz"),
         Required(ErrorMessage = "Telefon alaný boþ geçilemez"),
         Range(00000000000, 99999999999, ErrorMessage = "Telefon 11 rakamdan oluþmalýdýr")]
        public string phoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Epostanýz 50 karakterden fazla olamaz"),
         EmailAddress(ErrorMessage = "Eposta geçerli bir eposta adresi deðildir"),
         Required(ErrorMessage = "Eposta alaný boþ geçilemez")]
        public string email { get; set; }

        [StringLength(50, ErrorMessage = "Þifreniz 50 karakterden fazla olamaz"),
         MinLength(5, ErrorMessage = "Þifre 5 karakterden az olamaz"),
         Required(ErrorMessage = "Þifre alaný boþ geçilemez")]
        public string password { get; set; }

        public int? authorizationID { get; set; }

        [StringLength(50)]
        public string imageName { get; set; }

        public virtual Authorization Authorization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
