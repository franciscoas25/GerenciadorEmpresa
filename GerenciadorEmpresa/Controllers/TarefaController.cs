using AutoMapper;
using Gerenciador.Domain.Models;
using Gerenciador.Service.Interfaces;
using GerenciadorEmpresa.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaService tarefaService, IMapper mapper)
        {
            _tarefaService = tarefaService ?? throw new ArgumentNullException(nameof(tarefaService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllTarefasAsync()
        {
            try
            {
                var lstTarefas = await _tarefaService.GetAllTarefasAsync();

                var lstTarefasViewModel = _mapper.Map<List<TarefaViewModel>>(lstTarefas);

                return Ok(lstTarefasViewModel);
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return NotFound(msgErro);
            }
        }

        [HttpPost]
        [Route("AddAsync")]
        public async Task<IActionResult> AddTarefaAsync([FromBody] Tarefa tarefa)
        {
            try
            {
                await _tarefaService.AddTarefaAsync(tarefa);

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
        public async Task<IActionResult> UpdateTarefaAsync(Tarefa tarefa)
        {
            try
            {
                await _tarefaService.UpdateTarefaAsync(tarefa);

                return Ok();
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return StatusCode(500, msgErro);
            }
        }

        [HttpPut]
        [Route("UpdateStatusAsync/{tarefaId}")]
        public async Task<IActionResult> UpdateStatusAsync([FromRoute] string tarefaId)
        {
            try
            {
                await _tarefaService.UpdateStatusAsync(new Guid(tarefaId));

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
        public async Task<IActionResult> DeleteTarefaAsync([FromRoute] Guid id)
        {
            try
            {
                await _tarefaService.DeleteTarefaAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return StatusCode(500, msgErro);
            }
        }

        [HttpGet]
        [Route("FiltrarTarefasPorColaboradorAsync/{colaboradorId}")]
        public async Task<IActionResult> FiltrarTarefasPorColaboradorAsync([FromRoute] Guid colaboradorId)
        {
            try
            {
                var lstTarefasPorColaborador = await _tarefaService.FiltrarTarefasPorColaboradorAsync(colaboradorId);

                var lstTarefasPorColaboradorViewModel = _mapper.Map<List<TarefaViewModel>>(lstTarefasPorColaborador);

                return Ok(lstTarefasPorColaboradorViewModel);
            }
            catch (Exception ex)
            {
                string msgErro = ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : string.Empty);

                return NotFound(msgErro);
            }
        }
    }
}
