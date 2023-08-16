

using AutoMapper;
using Common.Persistence;
using Common.Queries;
using Localization.Application.Queries;
using Localization.Application.Responses;
using Localization.Application.Specifications.Colonias;
using Localization.Core;
using MediatR;

namespace Localization.Application.Handlers;

public class GetColoniasHandler: IRequestHandler<GetColoniasQuery, PaginationDto<ColoniaDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetColoniasHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginationDto<ColoniaDto>> Handle(GetColoniasQuery request, CancellationToken cancellationToken)
    {
        var specParams = new ColoniaSpecificationParams
        {
            CodigoPostal = request.CodigoPostal,
            CodigoPostalId = request.CodigoPostalId,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };
        var colonias = await _unitOfWork.Repository<Colonia,int>().GetAllWithSpec(new ColoniaSpecification(specParams));
        var totalColonias = await _unitOfWork.Repository<Colonia,int>().CountAsync(new ColoniaForCountingSpecification(specParams));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalColonias) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<ColoniaDto>>(colonias);
        var paisesByPage = colonias.Count();

        var pagination = new PaginationDto<ColoniaDto>
        {
            Count = totalColonias,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = paisesByPage
        };

        return pagination;
    }
}
