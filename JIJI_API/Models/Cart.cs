using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JIJI_API.Models
{
    [Table("cart")]
    public class Cart
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey("products")]
        public int product_id { get; set; }

        [Required]
        public int quantity { get; set; }
    }

}
