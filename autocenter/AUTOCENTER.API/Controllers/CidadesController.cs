using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadeService _service;

        public CidadesController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCidades")]
        public async Task<List<CidadeDTO>> Get()
        {
            var cidades = await _service.Get();
            return cidades;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CidadeDTO>> Get(int id)
        {
            var cidade = await _service.Get(id);
            if (cidade == null)
            {
                return NotFound();
            }

            return Ok(cidade);
        }

        [HttpPost]
        public async Task<ActionResult<CidadeDTO>> Create(CidadeDTO cidade)
        {
            try
            {
                var cidadeNovo = await _service.Create(cidade);
                return CreatedAtAction("Get", new { id = cidadeNovo.Id }, cidadeNovo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CidadeDTO cidade)
        {
            try
            {
                await _service.Update(cidade);
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