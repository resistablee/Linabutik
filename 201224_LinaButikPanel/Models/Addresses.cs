using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Addresses
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen bir adres başlığı giriniz.")]
        [StringLength(50, ErrorMessage = "Başlık en fazla 50 karakter uzunluğunda olabilir.")]
        [Display(Name = "Adres başlığı")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Lütfen şehir seçiniz.")]
        [Display(Name ="Şehir")]
        public Int16 CityID { get; set; } //FK


        [Required(ErrorMessage = "Lütfen ilçe seçiniz.")]
        [Display(Name = "İlçe")]
        public Int16 CountryID { get; set; } //FK

        [Required(ErrorMessage ="Müşteri bilgisi yok.")]
        [Display(Name = "Müşteri")]
        public int CustomerID { get; set; } //FK


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen bir telefon numarası giriniz.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, ErrorMessage = "Telefon numarası 11 karakter olmalıdır", MinimumLength = 14)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon numarası")]
        public string TelephoneNumber { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Posta kodunuzu giriniz.")]
        [DataType(DataType.PostalCode)]
        [StringLength(5, ErrorMessage = "Posta kodu 5 karakter uzunluğunda olmalıdır.", MinimumLength = 5)]
        [Display(Name = "Posta kodu")]
        public string PostCode { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen adresinizi giriniz.")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "Adresiniz, 20-250 karakter arası uzunlukta olmalıdır.", MinimumLength = 10)]
        [Display(Name = "Adres")]
        public string Address { get; set; }


        [ForeignKey("CityID")]
        public virtual Cities City { get; set; }

        [ForeignKey("CountryID")]
        public virtual Countries Country { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customers Customer { get; set; }



        public virtual ICollection<CargoInfo> awer2 { get; set; } //Address
        public virtual ICollection<Orders> awer42 { get; set; } //Address
        public virtual ICollection<OrderDetails> awer43 { get; set; } //Address
    }
}