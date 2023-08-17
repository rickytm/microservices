using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.Estados;

public class EstadoForCountingSpecification : BaseSpecification<Estado>
{
    public EstadoForCountingSpecification(EstadoSpecificationParams specParams)
        : base(x =>
            (string.IsNullOrEmpty(specParams.NombrePais) || x.Pais!.Name!.Contains(specParams.NombrePais) || x.Pais!.Clave!.Contains(specParams.NombrePais)) &&
            (!specParams.PaisId.HasValue || x.PaisId == specParams.PaisId) &&
            (string.IsNullOrEmpty(specParams.NombreEstado) || x.Name == specParams.NombreEstado)
        )
    {

    }
}
