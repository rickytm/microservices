namespace Common.Persistence.Contracts;

public interface IUnitOfWork : IDisposable
{
    IAsyncRepository<TEntity, TId> Repository<TEntity, TId>() where TEntity : class;
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    bool SaveChanges();
}