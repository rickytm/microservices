
using Catalog.Application.Responses;
using Catalog.Core;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductsQuery: PaginationBaseQuery, IRequest<PaginationDto<ProductDto>>
{
    public string BrandIds { get; set; } = string.Empty;
    public string AttributesIds { get; set; } = string.Empty;
    public string CategoryIds { get; set; } = string.Empty;
    public string Ratings { get; set; } = string.Empty;
    public decimal? PrecioMax { get; set; }
    public decimal? PrecioMin { get; set; }
    public ProductStatus? Status { get; set; }
    public bool IsFromAdmin { get; set; }
}
