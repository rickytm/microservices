
using AutoMapper;
using Common.Persistence;
using Common.Queries;
using Localization.Application.Queries;
using Localization.Application.Responses;
using Localization.Application.Specifications.CodigoPostales;
using Localization.Core;
using MediatR;

namespace Localization.Application.Handlers;
public class GetCodigoPostalesHandler : IRequestHandler<GetCodigoPostalesQuery, PaginationDto<CodigoPostalDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCodigoPostalesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationDto<CodigoPostalDto>> Handle(GetCodigoPostalesQuery request, CancellationToken cancellationToken)
    {
        var specParams = new CodigoPostalSpecificationParams
        {
            PageSize = request.PageSize,
            CodigoPostal = request.CodigoPostal,
            EstadoId = request.EstadoId,
            MunicipioId = request.MunicipioId,
            NombreEstado = request.NombreEstado,
            NombreMunicipio = request.NombreMunicipio,
            PageIndex = request.PageIndex,
            Search = request.Search,
            Sort = request.Sort
        };
        var codigoPostales = await _unitOfWork.Repository<CodigoPostal,int>().GetAllWithSpec(new CodigoPostalSpecification(specParams));
        var totalCodigoPostales = await _unitOfWork.Repository<CodigoPostal,int>().CountAsync(new CodigoPostalForCountingSpecification(specParams));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalCodigoPostales) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<CodigoPostalDto>>(codigoPostales);
        var paisesByPage = codigoPostales.Count();

        var pagination = new PaginationDto<CodigoPostalDto>
        {
            Count = totalCodigoPostales,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = paisesByPage
        };

        return pagination;
    }
}
