using Common.Queries;
using Localization.Application.Dtos;
using MediatR;

namespace Localization.Application.Queries;

public sealed record GetColoniasQuery(int? CodigoPostalId, string CodigoPostal) : PaginationBaseQuery, IRequest<PaginationDto<ColoniaDto>>;

public sealed record GetCodigoPostalesQuery(int? EstadoId, 
    int? MunicipioId, 
    string NombreEstado, 
    string NombreMunicipio, 
    string CodigoPostal) : PaginationBaseQuery, IRequest<PaginationDto<CodigoPostalDto>>;

public sealed record GetEstadosQuery(int? PaisId, string NombrePais, string NombreEstado) : PaginationBaseQuery, IRequest<PaginationDto<EstadoDto>>;

public sealed record GetMunicipiosQuery(int? EstadoId, string NombreEstado, string Name) : PaginationBaseQuery, IRequest<PaginationDto<MunicipioDto>>;

public sealed record GetPaisesQuery(string Name, string Clave) : PaginationBaseQuery, IRequest<PaginationDto<PaisDto>>;

