using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Basket: IDisposable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Müşteri bilgisi alınamadı.")]
        [Display(Name = "Müşteri")]
        public int CustomerID { get; set; } //FK


        [Required(ErrorMessage = "Ürün bilgisi alınamadı.")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; } //FK


        [Required(ErrorMessage = "Adet bilgisi alınamadı.")]
        [Range(1, 100000)]
        [Display(Name = "Adet")]
        public Int16 Piece { get; set; }


        [Required(ErrorMessage = "Toplam tutar bilgisi alınamadı.")]
        [DataType(DataType.Currency)]
        [Range(0,9999999)]
        [Display(Name = "Toplam tutar")]
        public decimal Total { get; set; }


        [ForeignKey("CustomerID")]
        public virtual Customers Customer { get; set; }


        [ForeignKey("ProductID")]
        public virtual Products Product { get; set; }

        public void Dispose () { }
    }
}