using System.Linq.Expressions;
using piqe.Models;

namespace piqe.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> filter);
        Task<T> QuerySingleAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByGuidAsync(Guid guid);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> SaveAsync();
    }
}