using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.Municipios;

public class MunicipioForCountingSpecification : BaseSpecification<Municipio>
{
    public MunicipioForCountingSpecification(MunicipioSpecificationParams specParams)
        :base(x => 
            (!specParams.EstadoId.HasValue || x.EstadoId == specParams.EstadoId) && 
            (string.IsNullOrEmpty(specParams.NombreEstado) || x.Estado!.Name == specParams.NombreEstado) &&
            (string.IsNullOrEmpty(specParams.Name) || x.Name == specParams.Name)
        )
    {
        AddInclude(x => x.Estado);        
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
