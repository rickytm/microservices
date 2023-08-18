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
public sealed record ProductDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Rating { get; set; }
    public string Vendedor { get; set; }
    public int Stock { get; set; }    
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public string CategoryNombre { get; set; }
    public string BrandNombre { get; set; }
    public ProductStatus Status { get; set; }
    public string StockLabel => Stock > 0 ? "Disponible" : "Agotado";
    public string StatusLabel => Status switch
    {
        ProductStatus.Activo => ProductStatusLabel.ACTIVO,
        ProductStatus.Inactivo => ProductStatusLabel.INACTIVO,
        _ => ProductStatusLabel.INACTIVO
    };
    public IReadOnlyList<ProductAttributeDto> Attributes { get; set; }
    public IReadOnlyList<ProductVariantDto> Variants { get; set; }
}
public sealed record ProductVariantDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get;set;}
    public Guid VariantId { get;set;} 
    public decimal Precio { get; set;}
    public string VariantNombre { get;set;} 
    public int Stock { get; set;} 
    public string StockLabel => Stock > 0 ? "Disponible" : "Agotado";
}
