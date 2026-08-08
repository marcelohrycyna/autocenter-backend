using AUTOCENTER.Service.DTOs;

namespace AUTOCENTER.Service.Interfaces
{
    public interface IBaseDTOService<T> where T : DTO
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T dto);
        Task Update(T dto);
        Task Delete(int id);
    }
}
