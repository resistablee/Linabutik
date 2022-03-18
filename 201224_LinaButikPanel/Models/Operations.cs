using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _201224_LinaButikPanel.Models
{
    public class Operations:IDisposable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Operasyon tipi bilgisi alınamadı.")]
        [Display(Name ="Operasyon tipi")]
        public Int16 OperationTypeID { get; set; }

        [Required(ErrorMessage = "Kişi tipi bilgisi alınamadı.")]
        [Display(Name ="Kişi tipi")]
        public Int16 PersonTypeID { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(50,ErrorMessage ="Kişi adı en fazla 50 karakter uzunluğunda olmalıdır.")]
        [Display(Name ="Kişi adı soyadı")]
        public string Person { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(20,ErrorMessage ="IP adresi en fazla 20 karakter olmalıdır.")]
        [Display(Name ="Ip adres")]
        public string Hostname { get; set; }

        [Display(Name ="İşlem tarihi")]
        public DateTime GMT { get; set; }


        [ForeignKey("OperationTypeID")]
        public virtual Features OperationType { get; set; }

        [ForeignKey("PersonTypeID")]
        public virtual Features PersonType { get; set; }

        public void Dispose() { }
    }
}