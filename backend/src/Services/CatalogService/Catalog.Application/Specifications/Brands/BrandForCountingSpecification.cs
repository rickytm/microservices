using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Brands;

public class BrandForCountingSpecification : BaseSpecification<Brand>
{
    public BrandForCountingSpecification(BrandSpecificationParams brandParams)
    : base(x => (string.IsNullOrEmpty(brandParams.Search) || x.Nombre!.Contains(brandParams.Search)))
    {

    }
}

