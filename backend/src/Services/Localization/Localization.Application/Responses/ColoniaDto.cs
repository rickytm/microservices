
namespace Localization.Application.Responses;

public class ColoniaDto : LocalizationDto
{
    public int CodigoPostalId { get; set; }
    public string CodigoPostal { get; set; }
    public string PaisNombre { get; set; }
    public string EstadoNombre { get; set; }
    public string MunicipioNombre { get; set; }
}
