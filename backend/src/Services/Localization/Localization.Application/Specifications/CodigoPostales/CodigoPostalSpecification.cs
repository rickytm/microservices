using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.CodigoPostales;

public class CodigoPostalSpecification : BaseSpecification<CodigoPostal>
{
    public CodigoPostalSpecification(CodigoPostalSpecificationParams specParams)
        : base(x =>
            (string.IsNullOrEmpty(specParams.CodigoPostal) || x.Clave == specParams.CodigoPostal) &&
            (string.IsNullOrEmpty(specParams.NombreMunicipio) || x.Municipio!.Name == specParams.NombreMunicipio) &&
            (string.IsNullOrEmpty(specParams.NombreEstado) || x.Municipio!.Estado.Name == specParams.NombreEstado) &&
            (!specParams.EstadoId.HasValue || x.Municipio!.EstadoId == specParams.EstadoId) &&
            (!specParams.MunicipioId.HasValue || x.MunicipioId == specParams.MunicipioId)
        )
    {
        AddInclude(x => x.Municipio);
        AddInclude("Municipio.Estado");
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        if (!string.IsNullOrEmpty(specParams.Sort))
        {
            switch (specParams.Sort)
            {
                case "nombreAsc":
                    AddOrderBy(p => p.Name);
                    break;

                case "nombreDesc":
                    AddOrderByDescending(p => p.Name);
                    break;

                default:
                    AddOrderBy(p => p.CreatedDate);
                    break;
            }
        }
        else
        {
            AddOrderBy(p => p.Id);
        }
    }
}

