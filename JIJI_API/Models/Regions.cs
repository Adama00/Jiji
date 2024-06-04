using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JIJI_API.Models
{
    [Table("regions")]
    public class Regions
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }
}
