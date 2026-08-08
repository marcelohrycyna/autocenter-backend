using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrdemServicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrdemServicoDTO> Create(OrdemServicoDTO dto)
        {
            var os = _mapper.Map<OrdemServico>(dto);
            var created = await _uow.OrdemServicoRepository.Create(os);
            await _uow.CommitAsync();
            return _mapper.Map<OrdemServicoDTO>(created);
        }

        public async Task Delete(int id)
        {
            await _uow.OrdemServicoRepository.Delete(id);
            await _uow.CommitAsync();
        }

        public async Task<List<OrdemServicoDTO>> Get()
        {
            var oss = await _uow.OrdemServicoRepository.Get();

            var result = _mapper.Map<List<OrdemServicoDTO>>(oss);
            return result;
        }

        public async Task<OrdemServicoDTO> Get(int id)
        {
            var os = await _uow.OrdemServicoRepository.Get(id);
            return _mapper.Map<OrdemServicoDTO>(os);
        }

        public async Task Update(OrdemServicoDTO dto)
        {
            var os = _mapper.Map<OrdemServico>(dto);
            await _uow.OrdemServicoRepository.Update(os);
            var servicos = os.OrdemServicoServicos.ToList();

            await _uow.OrdemServicoServicoRepository.UpdateAll(servicos);

            await _uow.CommitAsync();
        }

        public async Task<List<OrdemServicoDTO>> GetByClienteId(int clienteId)
        {
            var oss = await _uow.OrdemServicoRepository.GetByClienteId(clienteId);

            return _mapper.Map<List<OrdemServicoDTO>>(oss);
        }
    }
}