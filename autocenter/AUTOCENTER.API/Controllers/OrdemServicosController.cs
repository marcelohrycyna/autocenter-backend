using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdemServicosController : ControllerBase
    {
        private readonly IOrdemServicoService _service;
        private readonly IOrdemServicoPdfService _servicePdf;
        private readonly IOrdemServicoEmailService _serviceEmail;

        // DTO para facilitar o recebimento dos ids de cliente e Ordem de Servico
        public record EnviarEmailRequest(int ClienteId, int OsId);


        public OrdemServicosController(IOrdemServicoService service, IOrdemServicoPdfService servicePdf, IOrdemServicoEmailService serviceEmail)
        {
            _service = service;
            _servicePdf = servicePdf;
            _serviceEmail = serviceEmail;
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

        [HttpGet("pdf/{id}")]
        public async Task<FileStreamResult> GerarPdf(int id)
        {
            var file = (await _servicePdf.GerarPdf(id)).FirstOrDefault();
            
            var ms = file.OpenReadStream();
            return new FileStreamResult(ms, "application/pdf")
            {
                FileDownloadName = file.FileName
            };
        }

        [HttpPost("email")]
        public async Task<IActionResult> EnviarEmail([FromBody] EnviarEmailRequest request)
        {
            if (request.ClienteId <= 0 || request.OsId <= 0)
            {
                return BadRequest("Os campos ClienteId e OsId são obrigatórios e devem ser maiores que zero.");
            }

            var result = await _serviceEmail.EnviarEmail(request.ClienteId, request.OsId);
            return Ok(result);
        }
    }
}