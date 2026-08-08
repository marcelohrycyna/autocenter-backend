using AUTOCENTER.Infra.Repositories.Interfaces;
using AUTOCENTER.Service.DTOs;
using AUTOCENTER.Service.Interfaces;
using AUTOCENTER.Utils.DependencyInjectionAttributes.ServiceLifeTimeAttributes;
using AutoMapper;

namespace AUTOCENTER.Service.Services
{
    [Scoped]
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Create(ClienteDTO dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            var created = await _uow.ClienteRepository.Create(cliente);
            await _uow.CommitAsync();
            return _mapper.Map<ClienteDTO>(created);
        }

        public async Task Delete(int id)
        {
            await _uow.ClienteRepository.Delete(id);
            await _uow.CommitAsync();
        }

        public async Task<List<ClienteDTO>> Get()
        {
            var clientes = await _uow.ClienteRepository.Get();

            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> Get(int id)
        {
            var cliente = await _uow.ClienteRepository.Get(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task Update(ClienteDTO dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            await _uow.ClienteRepository.Update(cliente);
            await _uow.CommitAsync();
        }
    }
}