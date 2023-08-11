using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.Colonias;

public class ColoniaForCountingSpecification : BaseSpecification<Colonia>
{
    public ColoniaForCountingSpecification(ColoniaSpecificationParams specParams)
        : base(x =>
            (!specParams.CodigoPostalId.HasValue || x.CodigoPostalId == specParams.CodigoPostalId) &&
            (string.IsNullOrEmpty(specParams.CodigoPostal) || x.CodigoPostal!.Clave == specParams.CodigoPostal)
        )
    {
        AddInclude(x => x.CodigoPostal);
       
    }
}
