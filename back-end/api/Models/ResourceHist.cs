using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ResourceHist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User user { get; set; }

        [Required]
        public int Action { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}