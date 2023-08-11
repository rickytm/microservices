using Common.Specifications;

namespace Localization.Application.Specifications.Municipios;

public class MunicipioSpecificationParams : SpecificationParams
{
    public int? EstadoId { get; set; }
    public string NombreEstado { get; set; }
    public string Name { get; set; }
}

