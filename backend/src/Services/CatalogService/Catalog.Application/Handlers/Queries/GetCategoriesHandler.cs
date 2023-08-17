using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Dtos;
using Catalog.Application.Specifications.Categories;
using Catalog.Core;
using Common.Persistence.Contracts;
using Common.Queries;
using MediatR;
namespace Catalog.Application.Handlers.Queries;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, PaginationDto<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationDto<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var specParams = new CategorySpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };
        var results = await _unitOfWork.Repository<Category,Guid>().GetAllWithSpec(new CategorySpecification(specParams));
        var totalResults = await _unitOfWork.Repository<Category,Guid>().CountAsync(new CategoryForCountingSpecification(specParams));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalResults) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<CategoryDto>>(results);
        var paisesByPage = results.Count;

        var pagination = new PaginationDto<CategoryDto>
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
