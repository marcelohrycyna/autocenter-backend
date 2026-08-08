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
        Task Update(T obj);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<List<T>> Get();
    }
}