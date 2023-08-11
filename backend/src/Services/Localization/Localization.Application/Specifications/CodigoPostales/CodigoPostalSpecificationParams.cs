using Common.Specifications;

namespace Localization.Application.Specifications.CodigoPostales;
public class CodigoPostalSpecificationParams: SpecificationParams
{
    public int? EstadoId { get; set; }
    public int? MunicipioId { get; set; }
    public string NombreEstado { get; set; }
    public string NombreMunicipio { get; set; }
    public string CodigoPostal { get; set; }
}
