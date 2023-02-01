using Gerenciador.Service.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAllEmpresas() 
        {
            await _empresaService.GetAllEmpresas();

            return Ok();
        }
    }
}
