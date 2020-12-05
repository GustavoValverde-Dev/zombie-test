using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1, ErrorMessage="O nome do usuário deve conter no mínimo 1 caracter")]
        [MaxLength(45, ErrorMessage="O nome do usuário deve conter no máximo 40 caracteres")]
        [Required(ErrorMessage="Nome obrigatório")]
        public string Name { get; set; }

        [MinLength(1, ErrorMessage="O CPF deve conter 11 caracteres")]
        [MaxLength(45, ErrorMessage="O CPF deve conter 11 caracteres")]
        [Required(ErrorMessage="CPF obrigatório")]
        public string CPF { get; set; }

        [MinLength(1, ErrorMessage="A senha do usuário deve conter no mínimo 1 caracter")]
        [MaxLength(16, ErrorMessage="A senha do usuário deve conter no máximo 16 caracteres")]
        [Required(ErrorMessage="Senha obrigatória")]
        public string Password { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}