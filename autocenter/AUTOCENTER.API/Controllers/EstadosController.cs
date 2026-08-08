using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadoService _service;

        public EstadosController(IEstadoService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetEstados")]
        public async Task<List<EstadoDTO>> Get()
        {
            var estados = await _service.Get();
            return estados;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoDTO>> Get(int id)
        {
            var estado = await _service.Get(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        [HttpPost]
        public async Task<ActionResult<EstadoDTO>> Create(EstadoDTO estado)
        {
            try
            {
                estado.Pais = new Pais();
                var estadoNovo = await _service.Create(estado);
                return CreatedAtAction("Get", new { id = estadoNovo.Id }, estadoNovo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, EstadoDTO estado)
        {
            try
            {
                await _service.Update(estado);
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