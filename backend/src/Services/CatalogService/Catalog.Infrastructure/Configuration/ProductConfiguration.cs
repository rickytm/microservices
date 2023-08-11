using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Catalog.Core;

namespace Catalog.Infrastructure.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Vendedor).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(1000);
        builder.Ignore(p => p.Stock);

  
        builder
        .HasMany(p => p.Variants)
        .WithOne(pv => pv.Product)
        .HasForeignKey(pv => pv.ProductId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

    }
}

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        // Configuración de otras propiedades de ProductVariant
        builder.Property(p => p.Precio).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.VariantNombre).IsRequired().HasMaxLength(100);
        // Configuración de la propiedad de navegación Product
        builder.Ignore(pv => pv.ProductoNombre);
        builder.Ignore(pv => pv.ProductoDescripcion);
        builder.Ignore(pv => pv.VariantNombre);
    }
}


public class AttributeConfiguration : IEntityTypeConfiguration<Core.Attribute>
{
    public void Configure(EntityTypeBuilder<Core.Attribute> builder)
    {
        builder.Property(p => p.Key).HasMaxLength(50);
        builder.Property(p => p.Value).HasMaxLength(50);
    }
}

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(p => p.Nombre).HasMaxLength(100);
        builder.HasMany(p => p.Products)
        .WithOne(r => r.Brand)
        .HasForeignKey(f => f.BrandId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict);
    }
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Nombre).HasMaxLength(100);

        builder.HasMany(p => p.Products)
        .WithOne(r => r.Category)
        .HasForeignKey(f => f.CategoryId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Attributes)
        .WithOne(r => r.Category)
        .HasForeignKey(f => f.CategoryId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
}
