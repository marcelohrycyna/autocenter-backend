using AUTOCENTER.Domain.Models;
using AUTOCENTER.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AUTOCENTER.Infra.Repositories
{
    public class BaseRepositoryWithoutId<T> : IBaseRepositoryWithoutId<T> where T : BaseModelWithoutId
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepositoryWithoutId(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task CreateRange(List<T> objs)
        {
            if (_context is not null && objs is not null && objs.Count > 0)
            {
                _context.AddRange(objs);
                // Save is deferred to UnitOfWork.CommitAsync
                await Task.CompletedTask;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public virtual async Task DeleteRange(List<T> objs)
        {
            _context.RemoveRange(objs);
        }
    }
}