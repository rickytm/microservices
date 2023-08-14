using Common.Queries;
using Localization.Application.Responses;
using MediatR;

namespace Localization.Application.Queries;

public class GetColoniasQuery: PaginationBaseQuery, IRequest<PaginationDto<ColoniaDto>>
{
    public int? CodigoPostalId { get; set; }
    public string CodigoPostal {get; set;}
}

