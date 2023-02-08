using Gerenciador.Domain.Interfaces;
using Gerenciador.Domain.Models;
using Gerenciador.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Service.Implementation
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository ?? throw new ArgumentNullException(nameof(tarefaRepository));
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
        {
            return await _tarefaRepository.GetAllAsync();
        }

        public async Task AddTarefaAsync(Tarefa tarefa)
        {
            await _tarefaRepository.AddAsync(tarefa);
        }

        public async Task UpdateTarefaAsync(Tarefa tarefa)
        {
            if (tarefa == null)
                return;

            var tarefaDB = await _tarefaRepository.GetByIdAsync(tarefa.Id);

            if (tarefaDB == null)
                return;

            tarefaDB = tarefa;

            await _tarefaRepository.Update(tarefaDB);
        }

        public async Task UpdateStatusAsync(Guid tarefaId)
        {
            var tarefaDB = await _tarefaRepository.GetByIdAsync(tarefaId);

            if (tarefaDB == null)
                return;

            tarefaDB.Concluida = !tarefaDB.Concluida;

            await _tarefaRepository.Update(tarefaDB);
        }

        public async Task DeleteTarefaAsync(Guid id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);

            if (tarefa == null)
                return;

            await _tarefaRepository.Delete(tarefa);
        }

        public async Task<Tarefa> GetTarefaById(Guid id)
        {
            if (id == Guid.Empty)
                return new Tarefa();

            return await _tarefaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Tarefa>> FiltrarTarefasPorColaboradorAsync(Guid colaboradorId)
        {
            return await _tarefaRepository.FiltrarTarefasPorColaboradorAsync(colaboradorId);
        }
    }
}
