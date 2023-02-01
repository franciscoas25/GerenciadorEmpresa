namespace Gerenciador.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> GetAll();

        Task Add(T entity);

        Task<T> GetByIdAsync(Guid id);

        Task<int> SaveChangesAsync();
    }
}
