using Common.Queries;
using Localization.Application.Dtos;
using MediatR;

namespace Localization.Application.Queries;

public class GetEstadosQuery: PaginationBaseQuery, IRequest<PaginationDto<EstadoDto>>
{
    public int? PaisId {get; set; }
    public string NombrePais { get;set;}
    public string NombreEstado {get; set; }
}
