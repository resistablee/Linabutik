using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _201224_LinaButikPanel.Models
{
    public class Favorites
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Müşteri bilgisi alınamadı.")]
        [Display(Name = "Müşteri")]
        public int CustomerID { get; set; }


        [Required(ErrorMessage = "Ürün bilgisi alınamadı.")]
        [Display(Name = "Ürün")]
        public int ProductID { get; set; }


        [ForeignKey("CustomerID")]
        public virtual Customers Customer { get; set; }

        [ForeignKey("ProductID")]
        public virtual Products Product { get; set; }
    }
}