using Gerenciador.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Domain.Models
{
    public class Tarefa : BaseEntity
    {
        public string NomeTarefa { get; set; }
        public bool Concluida { get; set; }
        public Guid ColaboradorId { get; set; }
        public virtual Colaborador? Colaborador { get; set; }
    }
}
