using Gerenciador.Domain.Interfaces;
using Gerenciador.Domain.Models;
using Gerenciador.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.InfraStructure.Repository
{
    public class ColaboradorRepository : RepositoryBase<Colaborador>, IColaboradorRepository
    {
        private readonly GerenciadorEmpresaDB _gerenciadorEmpresaDB;

        public ColaboradorRepository(GerenciadorEmpresaDB gerenciadorEmpresaDB) : base(gerenciadorEmpresaDB)
        {
            _gerenciadorEmpresaDB = gerenciadorEmpresaDB ?? throw new ArgumentNullException(nameof(gerenciadorEmpresaDB));
        }

        public async Task<IEnumerable<Colaborador>> FiltrarColaboradoresPorEmpresaAsync(Guid empresaId)
        {
            if (empresaId == Guid.Empty)
                return Enumerable.Empty<Colaborador>();

            return  await _gerenciadorEmpresaDB.Colaborador.Where(x => x.EmpresaId == empresaId).ToListAsync();
        }
    }
}
