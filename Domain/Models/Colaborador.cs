using Gerenciador.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Domain.Models
{
    public class Colaborador : BaseEntity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string NomeColaborador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(5, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public int CEP { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no ´máximo {1} caracteres")]
        public string Complemento { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
