using Common.Specifications;

namespace Localization.Application.Specifications.Colonias;

public class ColoniaSpecificationParams: SpecificationParams
{
    public int? CodigoPostalId { get; set; }
    public string CodigoPostal { get; set; }
}
