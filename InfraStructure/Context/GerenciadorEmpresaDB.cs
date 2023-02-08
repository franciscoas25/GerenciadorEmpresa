using Gerenciador.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Gerenciador.InfraStructure.Context
{
    public class GerenciadorEmpresaDB : DbContext
    {
        public GerenciadorEmpresaDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
