using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _201224_LinaButikPanel.Models
{
    public class CargoInfo:IDisposable
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Sipariş bilgisi alınamadı.")]
        [Display(Name = "Sipariş no")]
        public int OrderID { get; set; } //FK


        [Required(ErrorMessage = "Müşteri bilgisi alınamadı.")]
        [Display(Name = "Müşteri")]
        public int CustomerID { get; set; } //FK


        [Required(ErrorMessage = "Adres bilgisi alınamadı.")]
        [Display(Name = "Adres")]
        public int AddressID { get; set; }


        [Required(ErrorMessage ="Kargo şirketi seçiniz.")]
        [Display(Name = "Kargo şirketi")]
        public Int16 CargoCompanyID { get; set; } //FK


        [Column(TypeName = "Nvarchar")]
        [StringLength(20,ErrorMessage ="Kargo takip no en fazla 30 karakter olabilir.")]
        [Display(Name = "Kargo takip numarası")]
        public string TruckNumber { get; set; }

        [Display(Name = "Tarih")]
        public DateTime GMT { get; set; }



        [ForeignKey("OrderID")]
        public virtual OrderDetails Order { get; set; }

        [ForeignKey("AddressID")]
        public virtual Addresses Address { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customers Customer { get; set; }

        [ForeignKey("CargoCompanyID")]
        public virtual Features CargoCompany { get; set; }


        public virtual ICollection<OrderDetails> awer5 { get; set; }


        public void Dispose() { }
    }
}