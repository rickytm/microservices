using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Products;
public class ProductForCountingSpecification : BaseSpecification<Product>
{
    public ProductForCountingSpecification(ProductSpecificationParams productParams)
    : base(x =>
        (string.IsNullOrWhiteSpace(productParams.Search) || x.Nombre!.Contains(productParams.Search) || x.Descripcion!.Contains(productParams.Search)) &&
        (!productParams.CategoryIds.Any() || productParams.CategoryIds.Contains(x.CategoryId)) &&
        (!productParams.BrandIds.Any() || productParams.BrandIds.Contains(x.BrandId!.Value)) &&
        (!productParams.Ratings.Any() || productParams.Ratings.Contains(x.Rating)) &&
        (!productParams.PrecioMin.HasValue || x.Variants!.Any(x => x.Precio >= productParams.PrecioMin)) &&
        (!productParams.PrecioMax.HasValue || x.Variants!.Any(x => x.Precio <= productParams.PrecioMax)) &&
        (!productParams.Status.HasValue || x.Status == productParams.Status) &&
        (!productParams.AttributesIds.Any() || x.Attributes!.Any(x => productParams.AttributesIds.Contains(x.AttributeId)))
    )
    {

    }
}
