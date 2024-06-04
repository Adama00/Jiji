using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JIJI_API.Models
{
    [Table("products")]
    public class Products
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public string description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }

        [Required]
        public int stock_quantity { get; set; }

        [ForeignKey("categories")]
        public int category_id { get; set; }

        [ForeignKey("regions")]
        public int region_id { get; set; }
    }

}
