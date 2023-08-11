using Common.Specifications;
using Localization.Core;

namespace Localization.Application.Specifications.Paises;
public class PaisSpecification : BaseSpecification<Pais>
{
    public PaisSpecification(PaisSpecificationParams specParams)
        :base(x => 
            (string.IsNullOrEmpty(specParams.Name) || x.Name == specParams.Name) &&
            (string.IsNullOrEmpty(specParams.Clave) || x.Clave == specParams.Clave)
        )
    {
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
