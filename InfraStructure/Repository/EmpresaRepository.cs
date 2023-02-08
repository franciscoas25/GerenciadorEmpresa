using Gerenciador.Domain.Interfaces;
using Gerenciador.Domain.Models;
using Gerenciador.InfraStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.InfraStructure.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(GerenciadorEmpresaDB gerenciadorEmpresaDB) : base(gerenciadorEmpresaDB)
        {
        }
    }
}
