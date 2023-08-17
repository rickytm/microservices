using Common.Queries;
using Localization.Application.Dtos;
using MediatR;

namespace Localization.Application.Queries;

public class GetCodigoPostalesQuery: PaginationBaseQuery, IRequest<PaginationDto<CodigoPostalDto>>
{
    public int? EstadoId { get; set; }
    public int? MunicipioId { get; set; }
    public string NombreEstado { get; set; }
    public string NombreMunicipio { get; set; }
    public string CodigoPostal { get; set; }
}
