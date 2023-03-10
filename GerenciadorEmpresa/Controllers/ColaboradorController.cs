using AutoMapper;
using Gerenciador.Domain.Models;
using Gerenciador.Service.Interfaces;
using GerenciadorEmpresa.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorColaborador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;

        public ColaboradorController(IColaboradorService colaboradorService, IEmpresaService empresaService, IMapper mapper)
        {
            _colaboradorService = colaboradorService ?? throw new ArgumentNullException(nameof(colaboradorService));
            _empresaService = empresaService ?? throw new ArgumentNullException(nameof(empresaService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllColaboradoresAsync()
        {
            try
            {
                var lstColaboradores = await _colaboradorService.GetAllColaboradoresAsync();

                var lstColaboradoresViewModel = _mapper.Map<List<ColaboradorViewModel>>(lstColaboradores);
                
                return Ok(lstColaboradoresViewModel);
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return NotFound(msgErro);
            }
        }

        [HttpPost]
        [Route("AddAsync")]
        public async Task<IActionResult> AddColaboradorAsync([FromBody] Colaborador colaborador)
        {
            try
            {
                await _colaboradorService.AddColaboradorAsync(colaborador);

                return Ok();
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return StatusCode(500, msgErro);
            }
        }

        [HttpPut]
        [Route("UpdateAsync")]
        public async Task<IActionResult> UpdateColaboradorAsync(Colaborador colaborador)
        {
            try
            {
                await _colaboradorService.UpdateColaboradorAsync(colaborador);

                return Ok();
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return StatusCode(500, msgErro);
            }
        }

        [HttpDelete]
        [Route("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteColaboradorAsync([FromRoute] Guid id)
        {
            try
            {
                await _colaboradorService.DeleteColaboradorAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return StatusCode(500, msgErro);
            }
        }

        [HttpGet]
        [Route("FiltrarColaboradoresPorEmpresaAsync/{empresaId}")]
        public async Task<IActionResult> FiltrarColaboradoresPorEmpresaAsync([FromRoute] Guid empresaId)
        {
            try
            {
                var lstColaboradoresPorEmpresa = await _colaboradorService.FiltrarColaboradoresPorEmpresaAsync(empresaId);
                
                return Ok(lstColaboradoresPorEmpresa);
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return NotFound(msgErro);
            }
        }
    }
}
