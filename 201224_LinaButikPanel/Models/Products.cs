using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori seçimi yapınız.")]
        [Display(Name = "Kategori")]
        public Int16 CategoryID { get; set; }

        [Column(TypeName = "Nvarchar"), StringLength(20)]
        [Required(ErrorMessage = "Ürün kodu oluşturulamadı.")]
        [Display(Name = "Ürün kodu")]
        public string ProductCode { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(100, ErrorMessage = "Ürün adı, 3-100 karakter arası olmalıdır.", MinimumLength = 3)]
        [Required(ErrorMessage = "Ürün adı yazın.")]
        [Display(Name = "Ürün adı")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Marka seçimi yapın.")]
        [Display(Name = "Marka")]
        public int BrandsID { get; set; }

        [Required(ErrorMessage = "Renk seçimi yapın.")]
        [Display(Name = "Renk")]
        public Int16 ColorID { get; set; }

        [Required(ErrorMessage = "Beden seçimi yapın.")]
        [Display(Name = "Beden")]
        public Int16 SizeID { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Fiyat değerini girin.")]
        [Display(Name = "Fiyat")]
        public int Price { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(1000, ErrorMessage = "Ürün açıklaması en fazla 1000 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Ürün stoğunu giriniz.")]
        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Required(ErrorMessage ="Satış durumunu seçiniz.")]
        [Display(Name = "Satışta mı?")]
        public bool SaleStatus { get; set; }


        [Required(ErrorMessage ="Ürünün durum bilgisi alınamadı.")]
        public bool Status { get; set; }





        [ForeignKey("BrandsID")]
        public virtual Brands Brand { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Features Category { get; set; }

        [ForeignKey("ColorID")]
        public virtual Features Color { get; set; }

        [ForeignKey("SizeID")]
        public virtual Features Size { get; set; }


        public virtual Int16[] Sizes { get; set; }

        public virtual ICollection<OrderDetails> awer26 { get; set; }
        public virtual ICollection<ProductImages> awer27 { get; set; }
        public virtual ICollection<Comments> awer28 { get; set; }
        public virtual ICollection<Favorites> awer29 { get; set; }
        public virtual ICollection<Basket> awer31 { get; set; }
    }
}