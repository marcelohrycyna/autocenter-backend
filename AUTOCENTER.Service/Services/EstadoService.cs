using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class EstadoService : IEstadoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EstadoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EstadoDTO> Create(EstadoDTO dto)
        {
            var estado = _mapper.Map<Estado>(dto);
            var created = await _uow.EstadoRepository.Create(estado);
            await _uow.CommitAsync();
            return _mapper.Map<EstadoDTO>(created);
        }

        public async Task Delete(int id)
        {
            await _uow.EstadoRepository.Delete(id);
            await _uow.CommitAsync();
        }

        public async Task<List<EstadoDTO>> Get()
        {
            var estados = await _uow.EstadoRepository.Get();

            return _mapper.Map<List<EstadoDTO>>(estados);
        }

        public async Task<EstadoDTO> Get(int id)
        {
            var estado = await _uow.EstadoRepository.Get(id);
            return _mapper.Map<EstadoDTO>(estado);
        }

        public async Task Update(EstadoDTO dto)
        {
            var estado = _mapper.Map<Estado>(dto);
            await _uow.EstadoRepository.Update(estado);
            await _uow.CommitAsync();
        }
    }
}