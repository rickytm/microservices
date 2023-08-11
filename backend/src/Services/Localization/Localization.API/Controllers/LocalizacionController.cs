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
        [ProducesResponseType(typeof(PaginationVm<PaisDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<PaisDto>>> PaginationPais([FromQuery] GetPaisesQuery query )
        {
           var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getEstados", Name = "PaginationEstado")]
        [ProducesResponseType(typeof(PaginationVm<EstadoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<EstadoDto>>> PaginationEstado([FromQuery] GetEstadosQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getMunicipios", Name = "PaginationMunicipio")]
        [ProducesResponseType(typeof(PaginationVm<MunicipioDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<MunicipioDto>>> PaginationMunicipio([FromQuery] GetMunicipiosQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getCodigoPostales", Name = "PaginationCodigoPostal")]
        [ProducesResponseType(typeof(PaginationVm<CodigoPostalDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<CodigoPostalDto>>> PaginationCodigoPostal([FromQuery] GetCodigoPostalesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getColonias", Name = "PaginacionColonia")]
        [ProducesResponseType(typeof(PaginationVm<ColoniaDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<ColoniaDto>>> PaginacionColonia([FromQuery] GetColoniasQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
