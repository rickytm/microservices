
namespace Localization.Application.Responses;
public class CodigoPostalDto : LocalizationDto
{
    public string PaisNombre { get; set; }
    public string EstadoNombre { get; set; }
    public string MunicipioNombre { get; set; }
    public string CodigoPostal { get; set; }
    public IEnumerable<ColoniaDto> Colonias { get; set; }
}
