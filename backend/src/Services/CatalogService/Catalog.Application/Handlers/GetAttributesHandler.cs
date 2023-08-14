using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Application.Specifications.Attributes;
using Common.Persistence;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Handlers;
public class GetAttributesHandler : IRequestHandler<GetAttributesQuery, PaginationDto<AttributeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAttributesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationDto<AttributeDto>> Handle(GetAttributesQuery request, CancellationToken cancellationToken)
    {
        var specParams = new AttributesSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search  = request.Search,
            Sort = request.Sort
        };
        var attributes = await _unitOfWork.Repository<Core.Attribute>().GetAllWithSpec(new AttributesSpecification(specParams));
        var totalAttributes= await _unitOfWork.Repository<Core.Attribute>().CountAsync(new AttributesForCountingSpecification(specParams));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalAttributes) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<AttributeDto>>(attributes);
        var paisesByPage = attributes.Count();

        var pagination = new PaginationDto<AttributeDto>
        {
            Count = totalAttributes,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = paisesByPage
        };

        return pagination;
    }
}