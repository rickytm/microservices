using AutoMapper;
using Common.Persistence;
using Common.Queries;
using Localization.Application.Queries;
using Localization.Application.Responses;
using Localization.Application.Specifications.Estados;
using Localization.Core;
using MediatR;

namespace Localization.Application.Handlers;

public class GetEstadosHandler : IRequestHandler<GetEstadosQuery, PaginationVm<EstadoDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEstadosHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationVm<EstadoDto>> Handle(GetEstadosQuery request, CancellationToken cancellationToken)
    {
        var estadosSpecParam = new EstadoSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            NombreEstado = request.NombreEstado,
            PaisId = request.PaisId,
            Search=request.Search,
            Sort=request.Sort,
        };
        var estados = await _unitOfWork.Repository<Estado>().GetAllWithSpec(new EstadoSpecification(estadosSpecParam));
        var totalEstados = await _unitOfWork.Repository<Estado>().CountAsync(new EstadoForCountingSpecification(estadosSpecParam));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalEstados) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<EstadoDto>>(estados);
        var estadosByPage = estados.Count();

        var pagination = new PaginationVm<EstadoDto>
        {            
            Count= totalEstados,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = estadosByPage
        };

        return pagination;
    }
}
