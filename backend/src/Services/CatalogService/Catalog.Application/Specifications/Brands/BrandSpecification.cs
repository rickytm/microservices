using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Brands;

public class BrandSpecification : BaseSpecification<Brand>
{
    public BrandSpecification(BrandSpecificationParams brandParams)
    : base(x => (string.IsNullOrEmpty(brandParams.Search) || x.Nombre!.Contains(brandParams.Search)))
    {
        ApplyPaging(brandParams.PageSize * (brandParams.PageIndex - 1), brandParams.PageSize);
        if (!string.IsNullOrEmpty(brandParams.Sort))
        {
            switch (brandParams.Sort)
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

