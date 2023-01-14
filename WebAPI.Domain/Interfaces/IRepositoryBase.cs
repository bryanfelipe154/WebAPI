using System.Linq.Expressions;

namespace WebAPI.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T?> FindByIdAsync(int id);
        Task<T?> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);
    }
}
