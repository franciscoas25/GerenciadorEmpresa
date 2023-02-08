using Gerenciador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Service.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
        Task AddEmpresaAsync(Empresa empresa);
        Task UpdateEmpresaAsync(Empresa empresa);
        Task DeleteEmpresaAsync(Guid id);
        Task<Empresa> GetEmpresaById(Guid id);
    }
}
