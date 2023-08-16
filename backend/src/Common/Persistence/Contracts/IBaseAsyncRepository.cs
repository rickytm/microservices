using System.Linq.Expressions;

namespace Common.Persistence.Contracts;

public interface IBaseAsyncRepository<T, TId> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate,
                           List<Expression<Func<T, object>>> include = null,
                           bool disableTracking = true);
    Task<T> GetByIdAsync(TId id);
    Task<bool> ExistsEntity(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteAsync(TId id);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
}
