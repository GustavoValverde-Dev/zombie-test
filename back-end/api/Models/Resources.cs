using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Resources
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1, ErrorMessage="O nome do recurso deve conter no mínimo 1 caracter")]
        [MaxLength(40, ErrorMessage="O nome do recurso deve conter no máximo 40 caracteres")]
        [Required(ErrorMessage="Nome obrigatório")]
        public string Name { get; set; }

        [MinLength(1, ErrorMessage="A descrição do recurso deve conter no mínimo 1 caracter")]
        [MaxLength(40, ErrorMessage="A descrição do recurso deve conter no máximo 40 caracteres")]
        [Required(ErrorMessage="Descrição obrigatória")]
        public string Description { get; set; }
        
        [Required(ErrorMessage="Quantidade obrigatória")]
        public int Quantity { get; set; }

        public string Observation { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}