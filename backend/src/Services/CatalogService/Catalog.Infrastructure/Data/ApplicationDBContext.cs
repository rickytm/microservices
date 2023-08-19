using Catalog.Core;
using Common.Audit;
using Common.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Catalog.Infrastructure.Data;

public class ApplicationDBContext : DbContext, IEntityFrameworkContext
{
    private readonly IAuditService _authAuditService;

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IAuditService authAuditService) : base(options)
    {
        _authAuditService = authAuditService;
    }

    public override int SaveChanges()
    {
        SetAuditData();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditData();
        return await base.SaveChangesAsync(cancellationToken);
        
    }   
    private void SetAuditData()
    {
        var username = _authAuditService.GetSessionUser() ?? "system";

        foreach (var entry in ChangeTracker.Entries<CatalogBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = username;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = username;
                    break;
                default:
                    break;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Core.Attribute> Attributes { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }    
    public DbSet<Variant> Variants { get; set; }

    EntityEntry<TEntity> IEntityFrameworkContext.Entry<TEntity>(TEntity entity)
    {
        return base.Entry(entity);
    }
}
