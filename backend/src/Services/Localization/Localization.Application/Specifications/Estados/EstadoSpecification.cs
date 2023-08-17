    using Common.Specifications;
    using Localization.Core;

    namespace Localization.Application.Specifications.Estados;
    public class EstadoSpecification : BaseSpecification<Estado>
    {
        public EstadoSpecification(EstadoSpecificationParams specParams)
            : base(x =>
                (string.IsNullOrEmpty(specParams.NombrePais) || x.Pais!.Name!.Contains(specParams.NombrePais) || x.Pais!.Clave!.Contains(specParams.NombrePais)) &&
                (!specParams.PaisId.HasValue || x.PaisId == specParams.PaisId) &&
                (string.IsNullOrEmpty(specParams.NombreEstado) || x.Name == specParams.NombreEstado)
            )
        {
            AddInclude(x => x.Pais);
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
