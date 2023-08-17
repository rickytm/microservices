
using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Dtos;
using Catalog.Application.Specifications.Products;
using Catalog.Core;
using Common.Extensions;
using Common.Persistence.Contracts;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, PaginationDto<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationDto<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var specParams = new ProductSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort,
            PrecioMax = request.PrecioMax,
            PrecioMin = request.PrecioMin,
            Status = request.Status,
            IsFromAdmin = request.IsFromAdmin,
            BrandIds = request.BrandIds.ConvertToListGuid(),
            CategoryIds = request.CategoryIds.ConvertToListGuid(),
            AttributesIds = request.AttributesIds.ConvertToListGuid(),
        };
        var results = await _unitOfWork.Repository<Product,Guid>().GetAllWithSpec(new ProductSpecification(specParams));
        var totalResults = await _unitOfWork.Repository<Product, Guid>().CountAsync(new ProductForCountingSpecification(specParams));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalResults) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<ProductDto>>(results);
        var paisesByPage = results.Count;

        var pagination = new PaginationDto<ProductDto>
        {
            Count = totalResults,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = paisesByPage
        };

        return pagination;
    }
}
