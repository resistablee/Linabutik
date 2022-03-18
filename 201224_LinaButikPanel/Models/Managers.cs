using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Models
{
    public class Managers
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "İsim girin.")]
        [StringLength(50, ErrorMessage = "İsim, 3-50 karakter arası olmalıdır", MinimumLength = 3)]
        [Display(Name = "İsim")]
        public string Name { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Soyad girin.")]
        [StringLength(20, ErrorMessage = "Soyad, 2-20 karakter arası olmalıdır.", MinimumLength = 2)]
        [Display(Name = "Soyisim")]
        public string Surname { get; set; }

        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Telefon numarası giriniz.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, ErrorMessage = "Telefon numarası 11 karakter olmalıdır", MinimumLength = 14)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon numarası")]
        [ConcurrencyCheck]
        public string TelephoneNumber { get; set; }

        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Mail adresi giriz.")]
        [DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi girin.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "Lütfen geçerli bir mail adresi girin.")]
        [StringLength(100, ErrorMessage = "Mail, en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Remote("IsManagerMailAvailable", "RemoteControl", ErrorMessage = "Bu mail zaten kayıtlı.")]
        [Display(Name = "E-posta")]
        [ConcurrencyCheck]
        public string Mail { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Kullanıcı adı girin.")]
        [StringLength(20, ErrorMessage = "Kullanıcı adı, 2-20 karakter arası olmalıdır.", MinimumLength = 2)]
        [Remote("IsManagerUserNameAvailable", "RemoteControl", ErrorMessage = "Bu kullanıcı adı zaten kayıtlı.")]
        [Display(Name = "Kullanıcı adı")]
        [ConcurrencyCheck]
        public string Username { get; set; }


        [Column(TypeName ="Nvarchar")]
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



        [Required(ErrorMessage = "Yetki derecesi belirleyin.")]
        [Display(Name = "Yetki seviyesi")]
        public Int16 AuthorityID { get; set; }



        [ForeignKey("AuthorityID")]
        public virtual Features Authority { get; set; }

    }
}