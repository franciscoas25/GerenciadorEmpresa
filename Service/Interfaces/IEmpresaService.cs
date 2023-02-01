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
        //IEnumerable<Empresa> GetAllEmpresas();

        Task<IEnumerable<Empresa>> GetAllEmpresas();
    }
}
