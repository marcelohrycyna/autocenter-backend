using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetClientes")]
        public async Task<List<ClienteDTO>> Get()
        {
            var clientes = await _service.Get();
            return clientes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _service.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Create(ClienteDTO cliente)
        {
            try
            {
                var clienteNovo = await _service.Create(cliente);
                return CreatedAtAction("Get", new { id = clienteNovo.Id }, clienteNovo);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ClienteDTO cliente)
        {
            try
            {
                await _service.Update(cliente);
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