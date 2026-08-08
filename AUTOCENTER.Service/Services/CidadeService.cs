using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class CidadeService : ICidadeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CidadeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CidadeDTO> Create(CidadeDTO dto)
        {
            var cidade = _mapper.Map<Cidade>(dto);
            var created = await _uow.CidadeRepository.Create(cidade);
            await _uow.CommitAsync();
            return _mapper.Map<CidadeDTO>(created);
        }

        public async Task Delete(int id)
        {
            await _uow.CidadeRepository.Delete(id);
            await _uow.CommitAsync();
        }

        public async Task<List<CidadeDTO>> Get()
        {
            var cidades = await _uow.CidadeRepository.Get();

            return _mapper.Map<List<CidadeDTO>>(cidades);
        }

        public async Task<CidadeDTO> Get(int id)
        {
            var cidade = await _uow.CidadeRepository.Get(id);
            return _mapper.Map<CidadeDTO>(cidade);
        }

        public async Task Update(CidadeDTO dto)
        {
            var cidade = _mapper.Map<Cidade>(dto);
            await _uow.CidadeRepository.Update(cidade);
            await _uow.CommitAsync();
        }
    }
}