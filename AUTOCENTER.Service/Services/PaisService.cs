using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class PaisService : IPaisService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PaisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaisDTO> Create(PaisDTO dto)
        {
            var pais = _mapper.Map<Pais>(dto);
            var created = await _uow.PaisRepository.Create(pais);
            await _uow.CommitAsync();
            return _mapper.Map<PaisDTO>(created);
        }

        public async Task Delete(int id)
        {
            await _uow.PaisRepository.Delete(id);
            await _uow.CommitAsync();
        }

        public async Task<List<PaisDTO>> Get()
        {
            var paises = await _uow.PaisRepository.Get();

            return _mapper.Map<List<PaisDTO>>(paises);
        }

        public async Task<PaisDTO> Get(int id)
        {
            var pais = await _uow.PaisRepository.Get(id);
            return _mapper.Map<PaisDTO>(pais);
        }

        public async Task Update(PaisDTO dto)
        {
            var pais = _mapper.Map<Pais>(dto);
            await _uow.PaisRepository.Update(pais);
            await _uow.CommitAsync();
        }
    }
}