using Common.Queries;
using Localization.Application.Responses;
using MediatR;

namespace Localization.Application.Queries;

public class GetEstadosQuery: PaginationBaseQuery, IRequest<PaginationVm<EstadoDto>>
{
    public int? PaisId {get; set; }
    public string NombreEstado {get; set; }
}
