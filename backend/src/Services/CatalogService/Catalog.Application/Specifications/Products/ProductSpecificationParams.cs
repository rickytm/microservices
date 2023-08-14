using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Products;

public class ProductSpecificationParams : SpecificationParams
{
    public List<int> BrandIds { get; set; } = new List<int>();
    public List<int> AttributesIds { get; set; } = new List<int>();
    public List<int> CategoryIds { get; set; } = new List<int>();
    public List<int> Ratings { get; set; } = new List<int>();
    public decimal? PrecioMax { get; set; }
    public decimal? PrecioMin { get; set; }
    public ProductStatus? Status { get; set; }
    public bool IsFromAdmin { get; set; }
}
