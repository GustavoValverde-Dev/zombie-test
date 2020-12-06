using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ResourceEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ResourceId { get; set; }
        public virtual Resource resource { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public int CreationUserId { get; set; }
        public virtual User creationUser { get; set; }
        
        [Required]
        public DateTime CreationDate { get; set; }

    }
}