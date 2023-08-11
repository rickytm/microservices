using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.Colonias;

public class ColoniaSpecification: BaseSpecification<Colonia>
{
    public ColoniaSpecification(ColoniaSpecificationParams specParams)
        :base(x=> 
            (!specParams.CodigoPostalId.HasValue || x.CodigoPostalId == specParams.CodigoPostalId) &&
            (string.IsNullOrEmpty(specParams.CodigoPostal) || x.CodigoPostal!.Clave == specParams.CodigoPostal)
        )
    {
        AddInclude(x=>x.CodigoPostal);
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
