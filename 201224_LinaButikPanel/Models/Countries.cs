using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Countries
    {
        [Key]
        public Int16 Id { get; set; }


        [Required(ErrorMessage ="Şehir bilgisi alınamadı.")]
        [Display(Name = "Şehir")]
        public Int16 CityID { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage ="İlçe giriniz.")]
        [StringLength(50,ErrorMessage ="Bölge en fazla 50 karakter uzunluğunda olmalıdır.")]
        [Display(Name = "İlçe")]
        public string Country { get; set; }




        [ForeignKey("CityID")]
        public virtual Cities City { get; set; }

        public virtual ICollection<Addresses> awer8 { get; set; }
    }
}