using Gerenciador.Domain.Models;
using Gerenciador.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorColaborador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService ?? throw new ArgumentNullException(nameof(colaboradorService));
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllColaboradoresAsync()
        {
            try
            {
                var lstColaboradores = await _colaboradorService.GetAllColaboradoresAsync();

                return Ok(lstColaboradores);
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
    }
}
