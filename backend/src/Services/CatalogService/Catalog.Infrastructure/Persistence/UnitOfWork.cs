using Catalog.Infrastructure.Data;
using Common.Persistence;
using System.Collections;

namespace Catalog.Infrastructure.Persistence;


public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly ApplicationDBContext _context;

    public UnitOfWork(ApplicationDBContext context)
    {
        _context = context;
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        if (_repositories is null)
        {
            _repositories = new Hashtable();
        }

        var type = typeof(TEntity).Name;

        if (!_repositories.Contains(type))
        {
            var repositoryType = typeof(AsyncRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)_repositories[type]!;
    }

    public bool SaveChanges()
    {
        try
        {
            return _context.SaveChanges() > 0;
        }
        catch (Exception e)
        {
            throw new Exception("Error en transacción", e);
        }
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch (Exception e)
        {
            throw new Exception("Error en transacción", e);
        }
    }
}