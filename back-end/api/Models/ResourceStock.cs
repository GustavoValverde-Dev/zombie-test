using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ResourceStock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ResourceId { get; set; }
        public virtual Resource resource { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}