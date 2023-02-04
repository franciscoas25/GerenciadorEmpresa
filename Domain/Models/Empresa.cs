using Gerenciador.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Domain.Models
{
    public class Empresa : BaseEntity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Celular { get; set; }
    }    
}
