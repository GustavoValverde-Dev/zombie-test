using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class TokenLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User user { get; set; }

        [MinLength(1, ErrorMessage="O Token deve conter no mínimo 1 caracter")]
        [MaxLength(100, ErrorMessage="O Token deve conter no máximo 100 caracteres")]
        [Required(ErrorMessage="Token obrigatório")]
        public string Token { get; set; }
        
        [Required]
        public DateTime ValidThru { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}