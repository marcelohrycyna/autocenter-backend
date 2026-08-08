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
                await _context.SaveChangesAsync();
                return obj;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }

            //try
            //{
            //    _context.Add(obj);
            //    await _context.SaveChangesAsync();
            //    return obj;
            //}
            //catch (DbUpdateException e)
            //{
            //    if (e.Message.Contains("unique") || e.InnerException.Message.Contains("ORA-0001") || e.InnerException.Message.Contains("unique") || e.InnerException.Message.Contains("restrição exclusiva"))
            //    {
            //        throw new DuplicatedEntryException($"Já existe um registro com o mesmo valor.");
            //    }
            //    throw new UnableToCreateException($"{e.InnerException.Message}\nStackTrace:{e.StackTrace}");
            //}
            //catch (Exception e)
            //{
            //    throw new UnableToCreateException($"{e.InnerException.Message}\nStackTrace:{e.StackTrace}");
            //}
        }


        public virtual async Task Update(T obj)
        {
            if (obj is not null)
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
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
                await _context.Paises.FirstAsync(p => p.Id == id);
                var pais = await _context.Set<T>().AsNoTracking().FirstAsync(p => p.Id == id);

                return pais;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
            
        } 
    }
}