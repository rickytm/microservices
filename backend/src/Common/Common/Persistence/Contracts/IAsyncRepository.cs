using Common.Specifications;
using System.Linq.Expressions;

namespace Common.Persistence.Contracts;

public interface IAsyncRepository<T, TId> : IBaseAsyncRepository<T, TId> where T : class
{
    IQueryable<T> GetAll();    
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                                    string includeString,
                                    bool disableTracking = true);
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    List<Expression<Func<T, object>>> includes = null,
                                    bool disableTracking = true);
    Task<T> GetEntityStrIncludeAsync(Expression<Func<T, bool>> predicate, List<string> includes = null, bool disableTracking = true);     
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void AddRange(IEnumerable<T> entities);
    void DeleteRange(IEnumerable<T> entities);
    Task<T> GetByIdWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);    
}
