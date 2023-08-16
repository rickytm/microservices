
using AutoMapper;
using Common.Persistence;
using Common.Queries;
using Localization.Application.Queries;
using Localization.Application.Responses;
using Localization.Application.Specifications.Paises;
using Localization.Core;
using MediatR;

namespace Localization.Application.Handlers;
public class GetPaisesHandler : IRequestHandler<GetPaisesQuery, PaginationDto<PaisDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPaisesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationDto<PaisDto>> Handle(GetPaisesQuery request, CancellationToken cancellationToken)
    {
        var paisesSpec = new PaisSpecificationParams
        {
            Clave = request.Clave,
            Name = request.Name,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort,
        };

        var paises = await _unitOfWork.Repository<Pais,int>().GetAllWithSpec(new PaisSpecification(paisesSpec));
        var totalPaises = await _unitOfWork.Repository<Pais,int>().CountAsync(new PaisForCountingSpecification(paisesSpec));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalPaises) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<PaisDto>>(paises);
        var paisesByPage = paises.Count();

        var pagination = new PaginationDto<PaisDto>
        {
            Count = totalPaises,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = paisesByPage
        };

        return pagination;

    }
}
