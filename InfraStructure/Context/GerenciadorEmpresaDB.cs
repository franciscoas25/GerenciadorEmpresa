using Microsoft.EntityFrameworkCore;

namespace Gerenciador.InfraStructure.Context
{
    public class GerenciadorEmpresaDB : DbContext
    {
        public GerenciadorEmpresaDB(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Cliente> Cliente { get; set; }
    }
}
