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

        [MaxLength(50, ErrorMessage = "Ad�n�z 50 karakterden fazla olamaz"),
         MinLength(3, ErrorMessage = "Ad 3 karakterden az olamaz"),
         Required(ErrorMessage = "Ad alan� bo� ge�ilemez")]
        public string name { get; set; }

        [StringLength(50, ErrorMessage = "Soyad�n�z 50 karakterden fazla olamaz"),
         MinLength(2, ErrorMessage = "Soyad 2 karakterden az olamaz"),
         Required(ErrorMessage = "Soyad alan� bo� ge�ilemez")]
        public string surname { get; set; }

        [StringLength(11, ErrorMessage = "Telefon 11 karakterden fazla olamaz"),
         MinLength(11, ErrorMessage = "Telefon 11 karakterden az olamaz"),
         Required(ErrorMessage = "Telefon alan� bo� ge�ilemez"),
         Range(00000000000, 99999999999, ErrorMessage = "Telefon 11 rakamdan olu�mal�d�r")]
        public string phoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Epostan�z 50 karakterden fazla olamaz"),
         EmailAddress(ErrorMessage = "Eposta ge�erli bir eposta adresi de�ildir"),
         Required(ErrorMessage = "Eposta alan� bo� ge�ilemez")]
        public string email { get; set; }

        [StringLength(50, ErrorMessage = "�ifreniz 50 karakterden fazla olamaz"),
         MinLength(5, ErrorMessage = "�ifre 5 karakterden az olamaz"),
         Required(ErrorMessage = "�ifre alan� bo� ge�ilemez")]
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
