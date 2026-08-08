using AUTOCENTER.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> Create(T obj);
        Task CreateRange(List<T> objs);
        Task Update(T obj);
        Task DeleteRange(List<T> objs);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<List<T>> Get();
    }
}