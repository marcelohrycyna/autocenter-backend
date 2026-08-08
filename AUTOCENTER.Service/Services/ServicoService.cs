using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class ServicoService : IServicoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ServicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServicoDTO> Create(ServicoDTO dto)
        {
            var servico = _mapper.Map<Servico>(dto);
            var created = await _uow.ServicoRepository.Create(servico);
            await _uow.CommitAsync();
            return _mapper.Map<ServicoDTO>(created);
        }

        public async Task Delete(int id)
        {
            await _uow.ServicoRepository.Delete(id);
            await _uow.CommitAsync();
        }

        public async Task<List<ServicoDTO>> Get()
        {
            var servicos = await _uow.ServicoRepository.Get();

            return _mapper.Map<List<ServicoDTO>>(servicos);
        }

        public async Task<ServicoDTO> Get(int id)
        {
            var servico = await _uow.ServicoRepository.Get(id);
            return _mapper.Map<ServicoDTO>(servico);
        }

        public async Task Update(ServicoDTO dto)
        {
            var servico = _mapper.Map<Servico>(dto);
            await _uow.ServicoRepository.Update(servico);
            await _uow.CommitAsync();
        }
    }
}