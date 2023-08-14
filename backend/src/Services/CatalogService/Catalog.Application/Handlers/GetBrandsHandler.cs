using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Application.Specifications.Brands;
using Catalog.Core;
using Common.Persistence;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetBrandsHandler : IRequestHandler<GetBrandsQuery, PaginationDto<BrandDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBrandsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationDto<BrandDto>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        var specParams = new BrandSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };
        var results = await _unitOfWork.Repository<Brand>().GetAllWithSpec(new BrandSpecification(specParams));
        var totalResults = await _unitOfWork.Repository<Brand>().CountAsync(new BrandForCountingSpecification(specParams));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalResults) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<BrandDto>>(results);
        var paisesByPage = results.Count;

        var pagination = new PaginationDto<BrandDto>
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
