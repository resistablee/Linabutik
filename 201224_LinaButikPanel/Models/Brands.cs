using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Brands
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage ="Bir marka girmelisiniz.")]
        [StringLength(50,ErrorMessage ="Marka adı en fazla 50 karakter olmalıdır.")]
        [Display(Name = "Marka")]
        public string Brand { get; set; }




        public virtual ICollection<Products> awer4 { get; set; }
    }
}