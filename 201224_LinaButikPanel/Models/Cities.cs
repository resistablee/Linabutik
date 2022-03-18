using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Cities
    {
        [Key]
        public Int16 Id { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(50,ErrorMessage ="Şehir en fazla 50 karakter uzunluğunda olabilir.")]
        [Display(Name = "Şehir")]
        public string City { get; set; }



        public virtual ICollection<Addresses> awer6 { get; set; }
        public virtual ICollection<Countries> awer7 { get; set; }
    }
}