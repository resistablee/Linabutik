using System.ComponentModel.DataAnnotations;

namespace _201224_LinaButikPanel.Models
{
    public class AdminAuthentication
    {

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [StringLength(20, ErrorMessage = "Kullanıcı adınız, 2-20 karakter arası uzunlukta olmalıdır.", MinimumLength = 2)]
        [Display(Name = "Kullanıcı adı")]
        public virtual string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Belirlediğiniz şifre 5-20 karakter arası uzunluktadır.", MinimumLength = 5)]
        [Display(Name = "Şifre")]
        public virtual string Password { get; set; }
    }
}