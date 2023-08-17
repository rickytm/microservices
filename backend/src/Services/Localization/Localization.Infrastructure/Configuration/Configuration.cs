using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Localization.Core;

namespace Localization.Infrastructure.Configuration;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Paises");
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Clave).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p => p.CreatedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.LastModifiedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.CreatedBy).HasMaxLength(50);
        builder.Property(p => p.LastModifiedBy).HasMaxLength(50);

        builder.HasMany(p => p.Estados)
            .WithOne(e => e.Pais)
            .HasForeignKey(e => e.PaisId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estados");
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Clave).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p => p.CreatedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.LastModifiedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.CreatedBy).HasMaxLength(50);
        builder.Property(p => p.LastModifiedBy).HasMaxLength(50);

        builder.HasMany(p => p.Municipios)
            .WithOne(e=> e.Estado)
            .HasForeignKey(e => e.EstadoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("Municipios");
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Clave).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p => p.CreatedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.LastModifiedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.CreatedBy).HasMaxLength(50);
        builder.Property(p => p.LastModifiedBy).HasMaxLength(50);

        builder.HasMany(p => p.CodigosPostales)
            .WithOne(p => p.Municipio)
            .HasForeignKey(p => p.MunicipioId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

    }
}

public class CodigoPostalConfiguration : IEntityTypeConfiguration<CodigoPostal>
{
    public void Configure(EntityTypeBuilder<CodigoPostal> builder)
    {
        builder.ToTable("CodigosPostales");
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Clave).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p => p.CreatedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.LastModifiedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.CreatedBy).HasMaxLength(50);
        builder.Property(p => p.LastModifiedBy).HasMaxLength(50);

        builder.HasMany(p => p.Colonias)
            .WithOne(p => p.CodigoPostal)
            .HasForeignKey(p => p.CodigoPostalId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ColoniaConfiguration : IEntityTypeConfiguration<Colonia>
{
    public void Configure(EntityTypeBuilder<Colonia> builder)
    {
        builder.ToTable("Colonias");
        builder.Property(p => p.Id)
           .HasColumnName("Id")
           .IsRequired();
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Clave).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p => p.CreatedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.LastModifiedDate).HasColumnType("timestamp without time zone");
        builder.Property(p => p.CreatedBy).HasMaxLength(50);
        builder.Property(p => p.LastModifiedBy).HasMaxLength(50);
    }
}
