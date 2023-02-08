using Gerenciador.Domain.Interfaces;
using Gerenciador.Domain.Models;
using Gerenciador.Service.Interfaces;

namespace Gerenciador.Service.Implementation
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository, IEmpresaRepository empresaRepository)
        {
            _colaboradorRepository = colaboradorRepository ?? throw new ArgumentNullException(nameof(colaboradorRepository));
            _empresaRepository = empresaRepository ?? throw new ArgumentNullException(nameof(empresaRepository));
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradoresAsync()
        {
            var lstColaboradores = await _colaboradorRepository.GetAllAsync();

            return await _colaboradorRepository.GetAllAsync();
        }

        public async Task AddColaboradorAsync(Colaborador colaborador)
        {
            var empresa = await _empresaRepository.GetByIdAsync(colaborador.EmpresaId).ConfigureAwait(false);

            if (empresa == null)
                return;

            colaborador.Empresa = empresa;

            await _colaboradorRepository.AddAsync(colaborador);
        }

        public async Task UpdateColaboradorAsync(Colaborador colaborador)
        {
            if (colaborador == null)
                return;

            var colaboradorDB = await _colaboradorRepository.GetByIdAsync(colaborador.Id);

            if (colaboradorDB == null)
                return;

            colaboradorDB = colaborador;

            await _colaboradorRepository.Update(colaboradorDB);
        }

        public async Task DeleteColaboradorAsync(Guid id)
        {
            var colaborador = await _colaboradorRepository.GetByIdAsync(id);

            if (colaborador == null)
                return;

            await _colaboradorRepository.Delete(colaborador);
        }

        public async Task<IEnumerable<Colaborador>> FiltrarColaboradoresPorEmpresaAsync(Guid empresaId)
        {
            if(empresaId == Guid.Empty)
                return Enumerable.Empty<Colaborador>();
            
            return await _colaboradorRepository.FiltrarColaboradoresPorEmpresaAsync(empresaId);
        }
    }
}
