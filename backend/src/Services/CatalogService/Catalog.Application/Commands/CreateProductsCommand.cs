using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Commands;
public class CreateProductsCommand:IRequest<Guid>
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Vendedor { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }    
    public IReadOnlyList<ProductAttributeDto> Attributes { get; set; }
    public IReadOnlyList<ProductVariantDto> Variants { get; set; }
}