﻿using Common.Persistence.Contracts;
using System.Collections;

namespace Common.Persistence;


public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly IEntityFrameworkContext _context;

    public UnitOfWork(IEntityFrameworkContext context)
    {
        _context = context;
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity, TId> Repository<TEntity, TId>() where TEntity : class
    {
        _repositories ??= new Hashtable();

        var type = typeof(TEntity).Name;

        if (!_repositories.Contains(type))
        {
            var repositoryType = typeof(AsyncRepository<,>).MakeGenericType(typeof(TEntity), typeof(TId));
            var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity, TId>)_repositories[type]!;
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

