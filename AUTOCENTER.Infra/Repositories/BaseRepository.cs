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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            if (_context is not null && obj is not null)
            {
                _context.Add(obj);
                // Save is deferred to UnitOfWork.CommitAsync
                return await Task.FromResult(obj);
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
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

        public virtual async Task Update(T obj)
        {
            if (obj is not null)
            {
                _context.Entry(obj).State = EntityState.Modified;
                // Save is deferred to UnitOfWork.CommitAsync
                await Task.CompletedTask;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }

        }

        public virtual async Task Delete(int id)
        {
            var obj = _context.Set<T>().Find(id);
            if (obj is not null)
            {
                _context.Remove(obj);
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


        public virtual async Task<List<T>> Get()
        {
            if (_context is not null)
            {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }
        public virtual async Task<T> Get(int id)
        {
            if (_context is not null)
            { 
                return await _context.Set<T>().AsNoTracking().FirstAsync(p => p.Id == id);
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
            
        } 
    }
}