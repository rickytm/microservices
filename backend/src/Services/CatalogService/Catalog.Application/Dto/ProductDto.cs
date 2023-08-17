using Catalog.Core;
namespace Catalog.Application.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Rating { get; set; }
    public string Vendedor { get; set; }
    public int Stock { get; set; }
    public string StockLabel => Stock > 0 ? "Disponible" : "Agotado";
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public string CategoryNombre { get; set; }
    public string BrandNombre { get; set; }    
    public ProductStatus Status { get; set; }
    public string StatusLabel
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
    public virtual IReadOnlyList<ProductAttributeDto> Attributes { get; set; }
    public virtual IReadOnlyList<ProductVariantDto> Variants { get; set; }
}

