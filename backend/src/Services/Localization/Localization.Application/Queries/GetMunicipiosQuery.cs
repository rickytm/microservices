using Common.Queries;
using Localization.Application.Responses;
using MediatR;

namespace Localization.Application.Queries;

public class GetMunicipiosQuery : PaginationBaseQuery, IRequest<PaginationVm<MunicipioDto>>
{
    public int? EstadoId {get; set; }
    public string NombreEstado {get;set; }
    public string Name {get; set; }
}
