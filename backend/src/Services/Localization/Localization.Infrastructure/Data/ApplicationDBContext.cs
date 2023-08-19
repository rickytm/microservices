using Common.Persistence.Contracts;
using Localization.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Localization.Infrastructure.Data;
public class ApplicationDBContext : DbContext, IEntityFrameworkContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public virtual DbSet<Pais> Paises { get; set; }
    public virtual DbSet<Estado> Estados { get; set; }
    public virtual DbSet<Municipio> Municipios { get; set; }
    public virtual DbSet<CodigoPostal> CodigosPostales { get; set; }
    public virtual DbSet<Colonia> Colonias { get; set; }

    EntityEntry<TEntity> IEntityFrameworkContext.Entry<TEntity>(TEntity entity)
    {
        return base.Entry(entity);
    }
}
