using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisService _service;

        public PaisesController(IPaisService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetPaises")]
        public async Task<List<PaisDTO>> Get()
        {
            var paises = await _service.Get();
            return paises;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDTO>> Get(int id)
        {
            var pais = await _service.Get(id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

        [HttpPost]
        public async Task<ActionResult<PaisDTO>> Create(PaisDTO pais)
        {
            try
            {
                var paisNovo = await _service.Create(pais);
                return CreatedAtAction("Get", new { id = paisNovo.Id }, paisNovo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PaisDTO pais)
        {
            try
            {
                await _service.Update(pais);
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