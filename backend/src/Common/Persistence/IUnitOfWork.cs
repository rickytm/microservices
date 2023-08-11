namespace Common.Persistence;

public interface IUnitOfWork : IDisposable
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);    
    bool SaveChanges();
}