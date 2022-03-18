using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class FeatureTypes
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(250,ErrorMessage ="Özellik tipi en fazla 250 karakter olabilir.")]
        [Display(Name = "Özellik türü")]
        public string Type { get; set; }

        public virtual ICollection<Features> awer24 { get; set; }
    }
}