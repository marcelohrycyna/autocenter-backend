using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdemServicosController : ControllerBase
    {
        private readonly IOrdemServicoService _service;

        public OrdemServicosController(IOrdemServicoService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetOrdemServicos")]
        public async Task<List<OrdemServicoDTO>> Get()
        {
            var oss = await _service.Get();
            return oss;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoDTO>> Get(int id)
        {
            var os = await _service.Get(id);
            if (os == null)
            {
                return NotFound();
            }

            return Ok(os);
        }

        [HttpGet("cliente/{clienteId:int}")]
        public async Task<List<OrdemServicoDTO>> GetByClienteId(int clienteId)
        {
            var oss = await _service.GetByClienteId(clienteId);
            return oss;
        }

        [HttpGet("status/{status?}")]
        public async Task<List<OrdemServicoDTO>> GetByStatus(bool? status)
        {
            var oss = await _service.GetByStatus(status);
            return oss;
        }

        [HttpPost]
        public async Task<ActionResult<OrdemServicoDTO>> Create(OrdemServicoDTO os)
        {
            try
            {
                var osNovo = await _service.Create(os);
                return CreatedAtAction("Get", new { id = osNovo.Id }, osNovo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, OrdemServicoDTO os)
        {
            try
            {
                await _service.Update(os);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(new { message = "Item removido com sucesso" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, id });
            }
        }
    }
}