using Common.Queries;
using Localization.Application.Dtos;
using MediatR;

namespace Localization.Application.Queries
{
    public class GetPaisesQuery: PaginationBaseQuery, IRequest<PaginationDto<PaisDto>>
    {
        public string Name { get; set; }
        public string Clave { get; set; }
    }
}
