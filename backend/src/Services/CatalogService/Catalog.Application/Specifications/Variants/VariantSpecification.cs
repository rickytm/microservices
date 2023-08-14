using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Variants;

public class VariantSpecification : BaseSpecification<Variant>
{
    public VariantSpecification(VariantSpecificationParams variantParams)
    : base(x => (string.IsNullOrEmpty(variantParams.Search) || x.Nombre!.Contains(variantParams.Search)))
    {
        ApplyPaging(variantParams.PageSize * (variantParams.PageIndex - 1), variantParams.PageSize);

        if (!string.IsNullOrEmpty(variantParams.Sort))
        {
            switch (variantParams.Sort)
            {
                case "nombreAsc":
                    AddOrderBy(p => p.Nombre!);
                    break;

                case "nombreDesc":
                    AddOrderByDescending(p => p.Nombre!);
                    break;

                default:
                    AddOrderBy(p => p.CreatedDate!);
                    break;
            }
        }
        else
        {
            AddOrderBy(p => p.Id);
        }
    }
}
