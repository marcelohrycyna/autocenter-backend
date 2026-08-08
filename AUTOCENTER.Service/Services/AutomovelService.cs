using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class AutomovelService : IAutomovelService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AutomovelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AutomovelDTO> Create(AutomovelDTO dto)
        {
            var automovel = _mapper.Map<Automovel>(dto);
            var created = await _uow.AutomovelRepository.Create(automovel);
            await _uow.CommitAsync();
            return _mapper.Map<AutomovelDTO>(created);
        }

        public async Task Delete(int id)
        {
            await _uow.AutomovelRepository.Delete(id);
            await _uow.CommitAsync();
        }

        public async Task<List<AutomovelDTO>> Get()
        {
            var automoveis = await _uow.AutomovelRepository.Get();

            return _mapper.Map<List<AutomovelDTO>>(automoveis);
        }

        public async Task<AutomovelDTO> Get(int id)
        {
            var automovel = await _uow.AutomovelRepository.Get(id);
            return _mapper.Map<AutomovelDTO>(automovel);
        }

        public async Task Update(AutomovelDTO dto)
        {
            var automovel = _mapper.Map<Automovel>(dto);
            await _uow.AutomovelRepository.Update(automovel);
            await _uow.CommitAsync();
        }

        public async Task<List<AutomovelDTO>> GetByClienteId(int clienteId)
        {
            var automoveis = await _uow.AutomovelRepository.GetByClienteId(clienteId);

            return _mapper.Map<List<AutomovelDTO>>(automoveis);
        }
    }
}