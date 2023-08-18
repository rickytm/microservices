using Catalog.Core;

namespace Catalog.Application.Dtos;

public static class ProductStatusLabel
{
    public const string ACTIVO = nameof(ACTIVO);
    public const string INACTIVO = nameof(INACTIVO);
}


public sealed record AttributeDto(Guid Id, Guid CategoryId, string Key, string Value);
public sealed record VariantDto(Guid Id, string Nombre);
public sealed record AttributeGroupedDto(string Key, string Value, IReadOnlyList<AttributeValueDto> Values);
public sealed record AttributeValueDto(Guid Id, Guid CategoryId, string Value, string Key);
public sealed record BrandDto(Guid Id, string Nombre);
public sealed record CategoryDto(Guid Id, Guid? ParentId, string ParentName, string Nombre, IReadOnlyList<AttributeDto> Attributes, IReadOnlyList<AttributeGroupedDto> AttributesGrouped);
public sealed record ProductAttributeDto(Guid Id, Guid ProductId, Guid CategoryId, Guid AttributeId, string Key, string Value, string ProductName, string CategoryName);

/*
 * string StockLabel => Stock > 0 ? "Disponible" : "Agotado";
 * string StatusLabel
    {
        get
        {
            switch (Status)
            {
                case ProductStatus.Activo:
                    {
                        return ProductStatusLabel.ACTIVO;
                    }
                case ProductStatus.Inactivo:
                    {
                        return ProductStatusLabel.INACTIVO;
                    }
                default: return ProductStatusLabel.INACTIVO;
            }
        }
        set { }
    }
 */
public sealed record ProductDto(Guid Id, string Nombre, string Descripcion, int Rating, string Vendedor, int Stock, string StockLabel, Guid CategoryId, Guid BrandId, string CategoryNombre, string BrandNombre, ProductStatus Status,
        string StatusLabel,
        IReadOnlyList<ProductAttributeDto> Attributes,
        IReadOnlyList<ProductVariantDto> Variants);

//public string StockLabel => Stock > 0 ? "Disponible" : "Agotado";
public sealed record ProductVariantDto(Guid Id, Guid ProductId, Guid VariantId, decimal Precio, string VariantNombre, int Stock, string StockLabel);
