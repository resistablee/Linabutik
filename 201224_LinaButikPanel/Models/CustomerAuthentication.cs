using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Models
{
    public class CustomerAuthentication
    {

        [Required(ErrorMessage = "Lütfen bir mail adresi giriz.")]
        [DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi girin.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "Lütfen geçerli bir mail adresi girin.")]
        [StringLength(100, ErrorMessage = "Mail, en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Display(Name = "E-posta")]
        public virtual string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre belirleyin.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Şifreniz, 5-20 karakter arası uzunlukta olmalıdır.", MinimumLength = 5)]
        [Display(Name = "Şifre")]
        public virtual string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public virtual bool remember { get; set; }
    }
}