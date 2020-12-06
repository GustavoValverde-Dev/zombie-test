using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ResourceTypeId { get; set; }
        public virtual ResourceType resourceType { get; set; }
        
        [MinLength(1, ErrorMessage="A descrição do recurso deve conter no mínimo 1 caracter")]
        [MaxLength(85, ErrorMessage="A descrição do recurso deve conter no máximo 85 caracteres")]
        [Required(ErrorMessage="Descrição obrigatória")]
        public string Description { get; set; }
        
        [Required]
        public bool Status { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }

        [MinLength(1, ErrorMessage="A observação do recurso deve conter no mínimo 1 caracter")]
        [MaxLength(85, ErrorMessage="A observação do recurso deve conter no máximo 85 caracteres")]
        public string Observation { get; set; }

        [Required]
        public int CreationUserId { get; set; }
        public virtual User creationUser { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}