using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly IServicoService _service;

        public ServicosController(IServicoService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetServicos")]
        public async Task<List<ServicoDTO>> Get()
        {
            var servicos = await _service.Get();
            return servicos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoDTO>> Get(int id)
        {
            var servico = await _service.Get(id);
            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        [HttpPost]
        public async Task<ActionResult<ServicoDTO>> Create(ServicoDTO servico)
        {
            try
            {
                var servicoNovo = await _service.Create(servico);
                return CreatedAtAction("Get", new { id = servicoNovo.Id }, servicoNovo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ServicoDTO servico)
        {
            try
            {
                await _service.Update(servico);
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