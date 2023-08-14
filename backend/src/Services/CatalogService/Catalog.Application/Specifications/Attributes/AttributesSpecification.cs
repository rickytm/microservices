using Common.Specifications;

namespace Catalog.Application.Specifications.Attributes;

public class AttributesSpecification : BaseSpecification<Core.Attribute>
{
    public AttributesSpecification(AttributesSpecificationParams attributesParams)
    : base(x => (string.IsNullOrEmpty(attributesParams.Search) || x.Key!.Contains(attributesParams.Search) || x.Value!.Contains(attributesParams.Search)))
    {
        ApplyPaging(attributesParams.PageSize * (attributesParams.PageIndex - 1), attributesParams.PageSize);
        if (!string.IsNullOrEmpty(attributesParams.Sort))
        {
            switch (attributesParams.Sort)
            {
                case "nombreAsc":
                    AddOrderBy(p => p.Key!);
                    break;

                case "nombreDesc":
                    AddOrderByDescending(p => p.Key!);
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

