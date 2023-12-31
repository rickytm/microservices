﻿using AutoMapper;
using Common.Persistence.Contracts;
using Common.Queries;
using Localization.Application.Queries;
using Localization.Application.Dtos;
using Localization.Application.Specifications.Estados;
using Localization.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Localization.Application.Handlers;

public class GetEstadosHandler : IRequestHandler<GetEstadosQuery, PaginationDto<EstadoDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEstadosHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaginationDto<EstadoDto>> Handle(GetEstadosQuery request, CancellationToken cancellationToken)
    {
        var paises = await _unitOfWork.Repository<Pais,int>().GetAll().Where(x => x.Name.Contains(request.NombrePais) || x.Clave.Contains(request.NombrePais)).Select(x => x.Id).ToListAsync();
        var estadosSpecParam = new EstadoSpecificationParams
        {
            NombrePais = request.NombrePais,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            NombreEstado = request.NombreEstado,
            PaisId = request.PaisId,
            Search=request.Search,
            Sort=request.Sort,
        };
        var estados = await _unitOfWork.Repository<Estado,int>().GetAllWithSpec(new EstadoSpecification(estadosSpecParam));
        var totalEstados = await _unitOfWork.Repository<Estado,int>().CountAsync(new EstadoForCountingSpecification(estadosSpecParam));
        var rounded = Math.Ceiling(Convert.ToDecimal(totalEstados) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);
        var data = _mapper.Map<IEnumerable<EstadoDto>>(estados);
        var estadosByPage = estados.Count();

        var pagination = new PaginationDto<EstadoDto>
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
