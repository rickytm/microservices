using Common.Specifications;

namespace Catalog.Application.Specifications.Attributes;

public class AttributesForCountingSpecification : BaseSpecification<Core.Attribute>
{
    public AttributesForCountingSpecification(AttributesSpecificationParams attributesParams)
    : base(x => (string.IsNullOrEmpty(attributesParams.Search) || x.Key!.Contains(attributesParams.Search) || x.Value!.Contains(attributesParams.Search)))
    { }
}

