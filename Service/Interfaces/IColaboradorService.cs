using Gerenciador.Domain.Models;

namespace Gerenciador.Service.Interfaces
{
    public interface IColaboradorService
    {
        Task AddColaboradorAsync(Colaborador colaborador);
        Task DeleteColaboradorAsync(Guid id);
        Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync();
        Task UpdateColaboradorAsync(Colaborador colaborador);
    }
}