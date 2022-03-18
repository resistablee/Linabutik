using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _201224_LinaButikPanel.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Ürün bilgisi alınamadı.")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; } //FK


        [Required(ErrorMessage = "Müşteri bilgisi alınamadı.")]
        [Display(Name = "Müşteri")]
        public int CustomerID { get; set; } //FK


        [Column(TypeName = "Nvarchar")]
        [StringLength(50, ErrorMessage ="Yorum başlığı en fazla 50 karakter olabilir.")]
        [Display(Name = "Yorum başlığı")]
        public string CommentTitle { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(500, ErrorMessage ="Yorum en fazla 500 karakter olabilir.")]
        [Display(Name = "Yorum")]
        public string Comment { get; set; }


        [Required(ErrorMessage = "Ürün puanını seçiniz.")]
        [Display(Name = "Puan")]
        public byte Point { get; set; }


        [Required(ErrorMessage ="Yorum görünürlüğü bilgisi alınamadı.")]
        [Display(Name = "Yorum görünürlüğü")]
        public bool CommentVisibility { get; set; }


        [Required(ErrorMessage ="Yorum tarih bilgisi alınamadı.")]
        [Display(Name = "Yorum tarihi")]
        public DateTime GMT { get; set; }


        [Required(ErrorMessage = "Yorum durumu girilmedi.")]
        [Display(Name = "Yorum durumu")]
        public bool Status { get; set; }




        [ForeignKey("ProductID")]
        public virtual Products Product { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customers Customer { get; set; }
    }
}