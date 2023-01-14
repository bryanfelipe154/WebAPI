using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Data.Context;

namespace WebAPI.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FindAsync(predicate);
        }

        public async Task<T?> AddAsync(T obj)
        {
            var dbset = _context.Set<T>();
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await FindByIdAsync(id);

            if (obj == null)
                return false;

            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            _context.Set<T>().Update(obj);

            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
