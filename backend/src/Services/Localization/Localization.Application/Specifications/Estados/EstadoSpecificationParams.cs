using Common.Specifications;

namespace Localization.Application.Specifications.Estados;

public class EstadoSpecificationParams : SpecificationParams
{
    public int? PaisId { get; set; }
    public string NombreEstado { get; set; }
}
