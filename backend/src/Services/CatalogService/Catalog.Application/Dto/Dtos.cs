using Catalog.Core;

namespace Catalog.Application.Dtos;

public static class ProductStatusLabel
{
    public const string ACTIVO = nameof(ACTIVO);
    public const string INACTIVO = nameof(INACTIVO);
}


public sealed record AttributeDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
public sealed record VariantDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
}
public sealed record AttributeGroupedDto
{
    public string Key { get; set; }
    public string Value { get; set; }
    public IReadOnlyList<AttributeValueDto> Values { get; set; }
}
public sealed record AttributeValueDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Value { get; set; }
    public string Key { get; set; }
}
public sealed record BrandDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
}
public sealed record CategoryDto
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string ParentName { get; set; }
    public string Nombre { get; set; }
    public IReadOnlyList<AttributeDto> Attributes { get; set; }
    public IReadOnlyList<AttributeGroupedDto> AttributesGrouped { get; set; }
}
public sealed record ProductAttributeDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AttributeId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
}
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
