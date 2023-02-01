using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Context
{
    public class GerenciadorEmpresaDB : DbContext
    {
        public GerenciadorEmpresaDB(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Cliente> Cliente { get; set; }
    }
}
