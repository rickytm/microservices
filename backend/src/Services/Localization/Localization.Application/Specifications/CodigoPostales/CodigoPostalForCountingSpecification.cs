using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.CodigoPostales;
public class CodigoPostalForCountingSpecification : BaseSpecification<CodigoPostal>
{
    public CodigoPostalForCountingSpecification(CodigoPostalSpecificationParams specParams)
        :base(x => 
            (string.IsNullOrEmpty(specParams.CodigoPostal) || x.Clave == specParams.CodigoPostal) &&
            (string.IsNullOrEmpty(specParams.NombreMunicipio) || x.Municipio!.Name == specParams.NombreMunicipio) &&
            (string.IsNullOrEmpty(specParams.NombreEstado) || x.Municipio!.Estado.Name == specParams.NombreEstado) &&
            (!specParams.EstadoId.HasValue || x.Municipio!.EstadoId == specParams.EstadoId) &&
            (!specParams.MunicipioId.HasValue || x.MunicipioId == specParams.MunicipioId)
        )
    {
        AddInclude(x=> x.Municipio);
        AddInclude("Municipio.Estado");
    }
}
