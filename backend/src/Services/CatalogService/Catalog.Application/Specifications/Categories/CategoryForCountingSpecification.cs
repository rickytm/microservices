using Catalog.Core;
using Common.Specifications;

namespace Catalog.Application.Specifications.Categories;

public class CategoryForCountingSpecification : BaseSpecification<Category>
{
    public CategoryForCountingSpecification(CategorySpecificationParams categoryParams)
    : base(x => (string.IsNullOrEmpty(categoryParams.Search) || x.Nombre!.Contains(categoryParams.Search)))
    {
    }
}
