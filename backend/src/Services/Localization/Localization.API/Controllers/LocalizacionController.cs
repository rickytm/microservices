using Common.Api;
using Common.Queries;
using Localization.Application.Queries;
using Localization.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Localization.API.Controllers
{
    public class LocalizacionController : BaseController
    {
        [HttpGet("getPaises", Name = "PaginationPais")]
        [ProducesResponseType(typeof(PaginationDto<PaisDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationDto<PaisDto>>> PaginationPais([FromQuery] GetPaisesQuery query )
        {
           var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getEstados", Name = "PaginationEstado")]
        [ProducesResponseType(typeof(PaginationDto<EstadoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationDto<EstadoDto>>> PaginationEstado([FromQuery] GetEstadosQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getMunicipios", Name = "PaginationMunicipio")]
        [ProducesResponseType(typeof(PaginationDto<MunicipioDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationDto<MunicipioDto>>> PaginationMunicipio([FromQuery] GetMunicipiosQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getCodigoPostales", Name = "PaginationCodigoPostal")]
        [ProducesResponseType(typeof(PaginationDto<CodigoPostalDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationDto<CodigoPostalDto>>> PaginationCodigoPostal([FromQuery] GetCodigoPostalesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getColonias", Name = "PaginacionColonia")]
        [ProducesResponseType(typeof(PaginationDto<ColoniaDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationDto<ColoniaDto>>> PaginacionColonia([FromQuery] GetColoniasQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
