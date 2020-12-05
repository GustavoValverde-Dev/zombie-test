using System;
using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Function
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1, ErrorMessage="A descrição deve conter no mínimo 1 caracter")]
        [MaxLength(45, ErrorMessage="A descrição deve conter no máximo 40 caracteres")]
        [Required(ErrorMessage="Descrição obrigatória")]
        public string Description { get; set; }

        [Required]
        public int CreationUserID { get; set; }
        public virtual User CreationUser {get; set;}

        [Required]
        public DateTime CreationDate { get; set; }
    }
}