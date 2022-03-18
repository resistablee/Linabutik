using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class OrderDetails: IDisposable
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Sipariş numarası alınamadı.")]
        [Display(Name ="Sipariş numarası")]
        public int OrderID { get; set; }


        [Required(ErrorMessage = "Ürün bilgisi alınamadı.")]
        [Display(Name ="Ürün")]
        public int ProductID { get; set; }


        [Required(ErrorMessage = "Sipariş durumu bilgisi alınamadı.")]
        [Display(Name ="Sipariş durumu")]
        public Int16 OrderStatusID { get; set; }

        [Required(ErrorMessage = "Birim fiyat bilgisi alınamadı.")]
        [Display(Name ="Birim fiyat")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Adet bilgisi alınamadı.")]
        [Display(Name ="Ürün adedi")]
        public Int16 Piece { get; set; }

        [Required(ErrorMessage = "Toplam tutar bilgisi alınamadı.")]
        [Display(Name ="Toplam tutar")]
        public decimal Total { get; set; }

        public int? CargoID { get; set; }




        [ForeignKey("ProductID")]
        public virtual Products Product { get; set; } //FK Features_ProductID

        [ForeignKey("OrderStatusID")]
        public virtual Features OrderStatus { get; set; } //FK Features_OrderStatus

        [ForeignKey("CargoID")]
        public virtual CargoInfo Cargo { get; set; } //FK CargoInfo_Id

        [ForeignKey("OrderID")]
        public virtual Orders Order { get; set; } //FK Orders_Id


        public virtual ICollection<CargoInfo> awer25 { get; set; } //PK Order




        public void Dispose() { }
    }
}