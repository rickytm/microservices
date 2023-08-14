using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Categories;

public class CategorySpecification : BaseSpecification<Category>
{
    public CategorySpecification(CategorySpecificationParams categorySpecificationParams) : base(x => (string.IsNullOrEmpty(categorySpecificationParams.Search) || x.Nombre!.Contains(categorySpecificationParams.Search)))
    {
        ApplyPaging(categorySpecificationParams.PageSize * (categorySpecificationParams.PageIndex - 1), categorySpecificationParams.PageSize);
        if (!string.IsNullOrEmpty(categorySpecificationParams.Sort))
        {
            switch (categorySpecificationParams.Sort)
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
