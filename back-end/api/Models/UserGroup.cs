using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User user { get; set; }

        [Required]
        public int GroupId { get; set; }
        public virtual Group group { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}