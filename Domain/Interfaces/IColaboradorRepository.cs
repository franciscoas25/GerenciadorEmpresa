using Gerenciador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Domain.Interfaces
{
    public interface IColaboradorRepository : IRepositoryBase<Colaborador>
    {
        //IEnumerable<Colaborador> FiltrarColaboradoresPorEmpresaAsync(Guid empresaId);

        Task<IEnumerable<Colaborador>> FiltrarColaboradoresPorEmpresaAsync(Guid empresaId);
    }
}
