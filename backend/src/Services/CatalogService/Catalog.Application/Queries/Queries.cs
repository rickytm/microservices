using Catalog.Application.Dtos;
using Catalog.Core;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Queries;
public sealed record GetBrandsQuery() : PaginationBaseQuery, IRequest<PaginationDto<BrandDto>>;
public sealed record GetAttributesQuery() : PaginationBaseQuery, IRequest<PaginationDto<AttributeDto>>;
public sealed record GetCategoriesQuery() : PaginationBaseQuery, IRequest<PaginationDto<CategoryDto>>;
public sealed record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
public sealed record GetProductsCountByStatusQuery(ProductStatus? Status) : IRequest<int>;
public sealed record GetProductsQuery : PaginationBaseQuery, IRequest<PaginationDto<ProductDto>>
{
    public string BrandIds { get; set; }
    public string AttributesIds { get; set; }
    public string CategoryIds { get; set; }
    public string Ratings { get; set; }
    public decimal? PrecioMax { get; set; }
    public decimal? PrecioMin { get; set; }
    public ProductStatus? Status { get; set; }
    public bool IsFromAdmin { get; set; }
}
public sealed record GetVariantsQuery() : PaginationBaseQuery, IRequest<PaginationDto<VariantDto>>;