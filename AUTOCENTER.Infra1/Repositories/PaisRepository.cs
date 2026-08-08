using AUTOCENTER.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AUTOCENTER.Infra.Repositories
{
    //[Scoped]
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {

        public PaisRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public async Task<Pais>Create(Pais pais)
        //{
        //    if (_context is not null && pais is not null && _context.Paises is not null)
        //    {
        //        _context.Paises.Add(pais);
        //        await _context.SaveChangesAsync();
        //        return pais;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Dados inválidos");
        //    }
        //}

        //public async Task Update(Pais pais)
        //{
        //    if (pais is not null)
        //    {
        //        _context.Entry(pais).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Dados inválidos");
        //    }
        //}        

        //public async Task Delete(int id)
        //{
        //    var livro = await Get(id);
        //    if (livro is not null)
        //    {
        //        _context.Paises.Remove(livro);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Dados inválidos");
        //    }
        //}

        //public async Task<List<Pais>> Get()
        //{
        //    if (_context is not null && _context.Paises is not null)
        //    {
        //        var paises = await _context.Paises.ToListAsync();
        //        return paises;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Dados inválidos");
        //    }
        //}

        //public async Task<Pais> Get(int id)
        //{
        //    var pais = await _context.Paises.FirstAsync(p => p.Id == id);
        //    if (pais is null)
        //    {
        //        throw new InvalidOperationException($"Pais com id {id} não encontrado");
        //    }
        //    return pais;
        //}
    }
}