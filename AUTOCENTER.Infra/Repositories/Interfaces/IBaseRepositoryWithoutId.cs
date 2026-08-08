using AUTOCENTER.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AUTOCENTER.Infra.Repositories.Interfaces
{
    public interface IBaseRepositoryWithoutId<T> where T : BaseModelWithoutId
    {
        Task CreateRange(List<T> objs);
        Task DeleteRange(List<T> objs);
    }
}