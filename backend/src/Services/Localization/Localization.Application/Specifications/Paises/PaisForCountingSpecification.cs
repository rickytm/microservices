using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.Paises;

public class PaisForCountingSpecification : BaseSpecification<Pais>
{
    public PaisForCountingSpecification(PaisSpecificationParams specParams)
        : base(x =>
            (string.IsNullOrEmpty(specParams.Name) || x.Name == specParams.Name) &&
            (string.IsNullOrEmpty(specParams.Clave) || x.Clave == specParams.Clave)
        )
    { }
}
