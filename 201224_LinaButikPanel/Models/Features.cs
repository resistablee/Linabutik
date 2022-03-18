using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Features
    {
        [Key]
        public Int16 Id { get; set; }


        [Required(ErrorMessage ="Özellik türü bilgisi alınamadı.")]
        [Display(Name = "Özellik türü")]
        public int FeatureTypeID { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(50,ErrorMessage ="Özellik türü en fazla 50 karakter olabilir.")]
        [Display(Name = "Özellik")]
        public string Property { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(50,ErrorMessage ="Açıklama en fazla 50 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string Des { get; set; }


        [ForeignKey("FeatureTypeID")]
        public virtual FeatureTypes FeatureType { get; set; }


        public virtual ICollection<Orders> awer50 { get; set; } //PaymentType
        public virtual ICollection<OrderDetails> awer16 { get; set; } //OrderStatus
        public virtual ICollection<Orders> awer41 { get; set; } //OrderStatus
        public virtual ICollection<Orders> awer80 { get; set; } //CardType

        public virtual ICollection<Products> awer17 { get; set; } //ColorID
        public virtual ICollection<Products> awer18 { get; set; } //SizeID
        public virtual ICollection<Products> awer19 { get; set; } //CategoryID

        public virtual ICollection<Operations> awer20 { get; set; } //OperationType
        public virtual ICollection<Operations> awer21 { get; set; } //PersonType

        public virtual ICollection<CargoInfo> awer22 { get; set; } //CargoCompany
        public virtual ICollection<Managers> awer23 { get; set; } //Authority

        public virtual ICollection<Customers> awer39 { get; set; } //GenderID
    }
}