using Gerenciador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Domain.Interfaces
{
    public interface ITarefaRepository : IRepositoryBase<Tarefa>
    {
        Task<IEnumerable<Tarefa>> FiltrarTarefasPorColaboradorAsync(Guid colaboradorId);
    }
}
