using Gerenciador.Domain.Interfaces;
using Gerenciador.Domain.Shared;
using Gerenciador.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.InfraStructure.Repository
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

        public async Task AddAsync(T entity)
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

        public async Task Update(T entity)
        {
            _gerenciadorEmpresaDB.Update(entity);

            await _gerenciadorEmpresaDB.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _gerenciadorEmpresaDB.Remove(entity);

            await _gerenciadorEmpresaDB.SaveChangesAsync();
        }
    }
}
