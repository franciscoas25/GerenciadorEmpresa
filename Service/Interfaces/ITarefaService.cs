using Gerenciador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Service.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAllTarefasAsync();
        Task AddTarefaAsync(Tarefa tarefa);
        Task UpdateTarefaAsync(Tarefa tarefa);
        Task DeleteTarefaAsync(Guid id);
        Task<Tarefa> GetTarefaById(Guid id);
        Task UpdateStatusAsync(Guid tarefaId);
        Task<IEnumerable<Tarefa>> FiltrarTarefasPorColaboradorAsync(Guid colaboradorId);
    }
}
