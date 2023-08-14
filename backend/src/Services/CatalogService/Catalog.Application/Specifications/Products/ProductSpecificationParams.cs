using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Products;

public class ProductSpecificationParams : SpecificationParams
{
    public List<Guid> BrandIds { get; set; } = new List<Guid>();
    public List<Guid> AttributesIds { get; set; } = new List<Guid>();
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
    public List<int> Ratings { get; set; } = new List<int>();
    public decimal? PrecioMax { get; set; }
    public decimal? PrecioMin { get; set; }
    public ProductStatus? Status { get; set; }
    public bool IsFromAdmin { get; set; }
}
