using Domain.Interfaces;
using Domain.Shared;
using InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly GerenciadorEmpresaDB _gerenciadorEmpresaDB;
        private readonly DbSet<T> _entities;

        public RepositoryBase(GerenciadorEmpresaDB gerenciadorEmpresaDB)
        {
            _gerenciadorEmpresaDB = gerenciadorEmpresaDB ?? throw new ArgumentNullException(nameof(gerenciadorEmpresaDB));
            _entities = _gerenciadorEmpresaDB.Set<T>() ?? throw new ArgumentNullException(nameof(_entities));
        }

        public async Task Add(T entity)
        {
            await _gerenciadorEmpresaDB.AddAsync(entity);
            await _gerenciadorEmpresaDB.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _gerenciadorEmpresaDB.SaveChangesAsync();
        }
    }
}
