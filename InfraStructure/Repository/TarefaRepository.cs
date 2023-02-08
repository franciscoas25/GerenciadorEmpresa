using Gerenciador.Domain.Interfaces;
using Gerenciador.Domain.Models;
using Gerenciador.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.InfraStructure.Repository
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        private readonly GerenciadorEmpresaDB _gerenciadorEmpresaDB;

        public TarefaRepository(GerenciadorEmpresaDB gerenciadorEmpresaDB) : base(gerenciadorEmpresaDB)
        {
            _gerenciadorEmpresaDB = gerenciadorEmpresaDB ?? throw new ArgumentNullException(nameof(gerenciadorEmpresaDB));
        }

        public async Task<IEnumerable<Tarefa>> FiltrarTarefasPorColaboradorAsync(Guid colaboradorId)
        {
            if (colaboradorId == Guid.Empty)
                return Enumerable.Empty<Tarefa>();

            return await _gerenciadorEmpresaDB.Tarefas.Where(x => x.ColaboradorId == colaboradorId).ToListAsync();
        }
    }
}
