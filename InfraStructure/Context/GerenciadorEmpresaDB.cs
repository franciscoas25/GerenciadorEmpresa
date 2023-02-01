using Gerenciador.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.InfraStructure.Context
{
    public class GerenciadorEmpresaDB : DbContext
    {
        public GerenciadorEmpresaDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
    }
}
