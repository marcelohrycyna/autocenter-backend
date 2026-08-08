using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomoveisController : ControllerBase
    {
        private readonly IAutomovelService _service;

        public AutomoveisController(IAutomovelService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAutomoveis")]
        public async Task<List<AutomovelDTO>> Get()
        {
            var automoveis = await _service.Get();
            return automoveis;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutomovelDTO>> Get(int id)
        {
            var automovel = await _service.Get(id);
            if (automovel == null)
            {
                return NotFound();
            }

            return Ok(automovel);
        }

        [HttpGet("cliente/{clienteId:int}")]
        public async Task<List<AutomovelDTO>> GetByClienteId(int clienteId)
        {
            var automoveis = await _service.GetByClienteId(clienteId);
            return automoveis;
        }

        [HttpPost]
        public async Task<ActionResult<AutomovelDTO>> Create(AutomovelDTO automovel)
        {
            try
            {
                var automovelNovo = await _service.Create(automovel);
                return CreatedAtAction("Get", new { id = automovelNovo.Id }, automovelNovo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, AutomovelDTO automovel)
        {
            try
            {
                await _service.Update(automovel);
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