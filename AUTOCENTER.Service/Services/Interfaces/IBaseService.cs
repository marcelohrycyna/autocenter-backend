using AUTOCENTER.Domain.Models;

namespace AUTOCENTER.Service.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseModel
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T dto);
        Task Update(T dto);
        Task Delete(int id);
    }
}