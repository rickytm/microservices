using Common.Queries;
using Localization.Application.Responses;
using MediatR;

namespace Localization.Application.Queries
{
    public class GetPaisesQuery: PaginationBaseQuery, IRequest<PaginationVm<PaisDto>>
    {
        public string Name { get; set; }
        public string Clave { get; set; }
    }
}
