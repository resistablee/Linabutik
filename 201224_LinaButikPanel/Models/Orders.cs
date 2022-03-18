using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Orders:IDisposable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Müşteri bilgisi alınamadı.")]
        [Display(Name ="Müşteri")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Ödeme tipi bilgisi alınamadı.")]
        [Display(Name ="Ödeme tipi")]
        public Int16 PaymentTypeID { get; set; }


        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Kart üzerindeki isim soyisimi giriniz.")]
        [StringLength(100, ErrorMessage = "Ad soyad, 3-100 karakter arası olmalıdır", MinimumLength = 3)]
        [Display(Name = "Kart üzerindeki isim")]
        [ConcurrencyCheck]
        public string CardOnName { get; set; }

        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen kart numarasını giriniz.")]
        [StringLength(19, ErrorMessage = "Kart numarası, 16 karakter olmalıdır", MinimumLength = 19)]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Kart numarası")]
        [ConcurrencyCheck]
        public string CardNumber { get; set; }

        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen kartın son kullanım tarihini girin.")]
        [StringLength(7, ErrorMessage = "Kartın son kullanım tarihi 4 haneli olmalıdır.", MinimumLength = 7)]
        [Display(Name = "Son kullanım tarihi")]
        [ConcurrencyCheck]
        public string CardExpirationDate { get; set; }

        [Column(TypeName = "Nvarchar")]
        [Required(ErrorMessage = "Lütfen kartın güvenlik kodunu girin.")]
        [StringLength(3, ErrorMessage = "Kartın güvenlik kodu 3 haneli olmalıdır.", MinimumLength = 3)]
        [Display(Name = "Güvenlik kodu")]
        [ConcurrencyCheck]
        public string CardSecurityCode { get; set; }

        [Required(ErrorMessage = "Sipariş durumu bilgisi alınamadı.")]
        [Display(Name ="Sipariş durumu")]
        public Int16 OrderStatusID { get; set; }

        [Required(ErrorMessage = "Toplam tutar bilgisi alınamadı.")]
        [Display(Name ="Toplam tutar")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Adres bilgisi alınamadı.")]
        [Display(Name ="Adres")]
        public int AddressID { get; set; }

        [Required(ErrorMessage = "Kart tipi seçilmedi.")]
        [Display(Name = "Kart tipi")]
        public Int16 CardTypeID { get; set; }

        [Display(Name ="Sipariş tarihi")]
        public DateTime GMT { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(20,ErrorMessage ="Ip adresi en fazla 20 karakter olmalıdır.")]
        [Display(Name ="Ip adres")]
        public string Hostname { get; set; }



        [ForeignKey("CustomerID")]
        public virtual Customers Customer { get; set; } //FK Customers_Id


        [ForeignKey("PaymentTypeID")]
        public virtual Features PaymentType { get; set; } //FK Features_PaymentType

        [ForeignKey("CardTypeID")]
        public virtual Features CardType { get; set; } //FK Features_CardType

        [ForeignKey("OrderStatusID")]
        public virtual Features OrderStatus { get; set; } // FK Features_OrderStatus

        [ForeignKey("AddressID")]
        public virtual Addresses Address { get; set; } //FK Addresses_Address



        public virtual OrderDetails Detail { get; set; } //FK Orders_Id



        public virtual ICollection<OrderDetails> awer61 { get; set; } //PaymentType

        public void Dispose() { }
    }
}