using Gerenciador.Domain.Interfaces;
using Gerenciador.Domain.Models;
using Gerenciador.Service.Interfaces;

namespace Gerenciador.Service.Implementation
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository ?? throw new ArgumentNullException(nameof(empresaRepository));
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
        {
            return await _empresaRepository.GetAllAsync();
        }

        public async Task AddEmpresaAsync(Empresa empresa)
        {
            await _empresaRepository.AddAsync(empresa);
        }

        public async Task UpdateEmpresaAsync(Empresa empresa)
        {
            if (empresa == null)
                return;

            var empresaDB = await _empresaRepository.GetByIdAsync(empresa.Id);

            if (empresaDB == null)
                return;

            empresaDB = empresa;
            
            await _empresaRepository.Update(empresaDB);
        }

        public async Task DeleteEmpresaAsync(Guid id)
        {
            var empresa = await _empresaRepository.GetByIdAsync(id);

            if (empresa == null)
                return;

            await _empresaRepository.Delete(empresa);
        }

        public async Task<Empresa> GetEmpresaById(Guid id)
        {
            if (id == Guid.Empty)
                return new Empresa();

            return await _empresaRepository.GetByIdAsync(id);
        }
    }
}
