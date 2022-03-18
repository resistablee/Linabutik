using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Models
{
    //ConcurrencyCheck Nedir?
    //https://www.gencayyildiz.com/blog/entity-framework-core-data-concurrency/


    public class Customers
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen ad ve soyad giriniz.")]
        [StringLength(100, ErrorMessage = "Ad soyad, 3-100 karakter arası olmalıdır", MinimumLength = 3)]
        [Display(Name = "Ad soyad")]
        [ConcurrencyCheck]
        public string NameSurname { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen bir mail adresi giriz.")]
        [DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi girin.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "Lütfen geçerli bir mail adresi girin.")]
        [StringLength(100, ErrorMessage = "Mail, en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Remote("IsCustomerMailAvailable", "RemoteControl", ErrorMessage = "Bu mail zaten kayıtlı.")]
        [Display(Name = "E-posta")]
        [ConcurrencyCheck]

        public string Mail { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen bir şifre belirleyin.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Şifreniz, 5-20 karakter arası uzunlukta olmalıdır.", MinimumLength = 5)]
        [Display(Name = "Şifre")]
        [ConcurrencyCheck]
        public string Password { get; set; }


        [Required(ErrorMessage = "Lütfen şifrenizi tekrar girin.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Şifreniz, 5-20 karakter arası uzunlukta olmalıdır.", MinimumLength = 5)]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Password), ErrorMessage = "Şifreniz aynı değil")]
        [Display(Name = "Şifre tekrar")]
        public virtual string RetypePassword { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen bir telefon numarası giriniz.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, ErrorMessage = "Telefon numarası 11 karakter olmalıdır", MinimumLength = 14)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon numarası")]
        [ConcurrencyCheck]
        public string TelephoneNumber { get; set; }


        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DataType(DataType.DateTime, ErrorMessage = "{0} formatı hatalı!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage ="Cinsiyetinizi seçiniz.")]
        [Display(Name = "Cinsiyet")]
        public Int16 GenderID { get; set; }


        [Required(ErrorMessage ="Müşteri durumu bilgisi alınamadı.")]
        [Display(Name = "Durum")]
        public bool Status { get; set; }



        [ForeignKey("GenderID")]
        public virtual Features Gender { get; set; }

        public virtual ICollection<OrderDetails> awer9 { get; set; }
        public virtual ICollection<Orders> awer60 { get; set; }
        public virtual ICollection<Addresses> awer10 { get; set; }
        public virtual ICollection<Comments> awer11 { get; set; }
        public virtual ICollection<Favorites> awer12 { get; set; }
        public virtual ICollection<Basket> awer13 { get; set; }
        public virtual ICollection<CargoInfo> awer14 { get; set; }
    }
}