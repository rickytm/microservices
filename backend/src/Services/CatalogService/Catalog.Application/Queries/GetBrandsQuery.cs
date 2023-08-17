using Catalog.Application.Dtos;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Queries;

public class GetBrandsQuery: PaginationBaseQuery, IRequest<PaginationDto<BrandDto>>
{
}
