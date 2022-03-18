using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class ProductImages
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün bilgisi alınamadı.")]
        [Display(Name ="Ürün kodu")]
        public int ProductID { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(400, ErrorMessage = "Resim seçin.")]
        [Required(ErrorMessage = "Ürün resmi seçiniz.")]
        public string URL { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(250,ErrorMessage ="Resim açıklaması en fazla ")]
        public string Description { get; set; }


        [ForeignKey("ProductID")]
        public virtual Products Product { get; set; }
    }
}