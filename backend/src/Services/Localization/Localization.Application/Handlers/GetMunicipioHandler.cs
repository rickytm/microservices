﻿
using AutoMapper;
using Common.Persistence;
using Common.Queries;
using Localization.Application.Queries;
using Localization.Application.Responses;
using Localization.Application.Specifications.Municipios;
using Localization.Core;
using MediatR;

namespace Localization.Application.Handlers;
public class GetMunicipioHandler : IRequestHandler<GetMunicipiosQuery, PaginationVm<MunicipioDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMunicipioHandler(IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationVm<MunicipioDto>> Handle(GetMunicipiosQuery request, CancellationToken cancellationToken)
    {
        var municipioSpec = new MunicipioSpecificationParams
        {
            EstadoId = request.EstadoId,
            Name = request.Name,
            NombreEstado = request.NombreEstado,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort,
        };

        var municipios = await _unitOfWork.Repository<Municipio>().GetAllWithSpec(new MunicipioSpecification(municipioSpec));
        var totalMunicipios = await _unitOfWork.Repository<Municipio>().CountAsync(new MunicipioForCountingSpecification(municipioSpec));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalMunicipios) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<MunicipioDto>>(municipios);
        var paisesByPage = municipios.Count;

        var pagination = new PaginationVm<MunicipioDto>
        {
            Count = totalMunicipios,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = paisesByPage
        };

        return pagination;
    }
}
