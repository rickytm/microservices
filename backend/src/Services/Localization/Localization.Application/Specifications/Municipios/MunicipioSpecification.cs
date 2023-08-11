using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.Municipios;
public class MunicipioSpecification : BaseSpecification<Municipio>
{
    public MunicipioSpecification(MunicipioSpecificationParams specParams)
        : base(x =>
            (!specParams.EstadoId.HasValue || x.EstadoId == specParams.EstadoId) &&
            (string.IsNullOrEmpty(specParams.NombreEstado) || x.Estado!.Name == specParams.NombreEstado) &&
            (string.IsNullOrEmpty(specParams.Name) || x.Name == specParams.Name)
        )
    {

    }
}