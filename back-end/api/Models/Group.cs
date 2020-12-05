using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1, ErrorMessage="A descrição deve conter no mínimo 1 caracter")]
        [MaxLength(45, ErrorMessage="A descrição deve conter no máximo 40 caracteres")]
        [Required(ErrorMessage="Descrição obrigatória")]
        public string Description { get; set; }

        [Required]
        public int FunctionId { get; set; }
        public virtual Function function { get; set; }

        [Required]
        public int CreationUserId { get; set; }
        public virtual User creationUser { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}