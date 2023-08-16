
using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Application.Specifications.Variants;
using Catalog.Core;
using Common.Persistence;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public class GetVariantsHandler : IRequestHandler<GetVariantsQuery, PaginationDto<VariantDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVariantsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginationDto<VariantDto>> Handle(GetVariantsQuery request, CancellationToken cancellationToken)
    {
        var specParams = new VariantSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };
        var results = await _unitOfWork.Repository<Variant, Guid>().GetAllWithSpec(new VariantSpecification(specParams));
        var totalResults = await _unitOfWork.Repository<Variant, Guid>().CountAsync(new VariantForCountingSpecification(specParams));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalResults) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<VariantDto>>(results);
        var paisesByPage = results.Count;

        var pagination = new PaginationDto<VariantDto>
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
