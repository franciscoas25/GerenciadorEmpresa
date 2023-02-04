namespace Gerenciador.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> GetAll();

        Task AddAsync(T entity);

        Task<T> GetByIdAsync(Guid id);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
