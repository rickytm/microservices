using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Variants;

public class VariantForCountingSpecification : BaseSpecification<Variant>
{
    public VariantForCountingSpecification(VariantSpecificationParams variantParams)
    : base(x => (string.IsNullOrEmpty(variantParams.Search) || x.Nombre!.Contains(variantParams.Search)))
    {

    }
}
