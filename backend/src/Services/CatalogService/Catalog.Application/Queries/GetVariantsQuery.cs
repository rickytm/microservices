
using Catalog.Application.Dtos;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Queries;

public class GetVariantsQuery:PaginationBaseQuery, IRequest<PaginationDto<VariantDto>>
{
}
