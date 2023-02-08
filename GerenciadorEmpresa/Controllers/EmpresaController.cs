using Gerenciador.Domain.Models;
using Gerenciador.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService ?? throw new ArgumentNullException(nameof(empresaService));
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllEmpresasAsync() 
        {
            try
            {
                var lstEmpresas = await _empresaService.GetAllEmpresasAsync();

                return Ok(lstEmpresas);
            }
            catch(Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return NotFound(msgErro);
            }           
        }

        [HttpPost]
        [Route("AddAsync")]
        public async Task<IActionResult> AddEmpresaAsync([FromBody] Empresa empresa)
        {
            try 
            {
                await _empresaService.AddEmpresaAsync(empresa);

                return Ok();
            }
            catch(Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);
                
                return StatusCode(500, msgErro);
            }
        }

        [HttpPut]
        [Route("UpdateAsync")]
        public async Task<IActionResult> UpdateEmpresaAsync(Empresa empresa)
        {
            try
            {
                await _empresaService.UpdateEmpresaAsync(empresa);

                return Ok();
            }
            catch(Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return StatusCode(500, msgErro);
            }
        }

        [HttpDelete]
        [Route("DeleteAsync/{empresaId}")]
        public async Task<IActionResult> DeleteEmpresaAsync([FromRoute] Guid empresaId)
        {
            try
            {
                await _empresaService.DeleteEmpresaAsync(empresaId);

                return Ok();
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return StatusCode(500, msgErro);
            }
        }
    }
}
