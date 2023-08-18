using Catalog.Application.Commands;
using Catalog.Application.Dtos;
using Catalog.Application.Queries;
using Catalog.Core;
using Common.Api;
using Common.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using C = Common.Constants;
namespace Catalog.API.Controllers;

public class ProductController : BaseController
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [AllowAnonymous]
    [HttpGet("pagination", Name = "PaginationProduct")]
    [ProducesResponseType(typeof(PaginationDto<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PaginationDto<ProductDto>>> PaginationProduct([FromQuery] GetProductsQuery paginationProductsQuery)
    {
        paginationProductsQuery.Status = ProductStatus.Activo;
        var paginationProduct = await Mediator.Send(paginationProductsQuery);
        return Ok(paginationProduct);
    }

    //[Authorize(Roles = C.ADMIN)]
    [HttpGet("paginationadmin", Name = "PaginationProductAdmin")]
    [ProducesResponseType(typeof(PaginationDto<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PaginationDto<ProductDto>>> PaginationProductAdmin([FromQuery] GetProductsQuery paginationProductsQuery)
    {
        paginationProductsQuery.IsFromAdmin = true;
        var paginationProduct = await Mediator.Send(paginationProductsQuery);
        return Ok(paginationProduct);
    }

    [AllowAnonymous]
    [HttpGet("{id}", Name = "GetProductById")]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
    {
        return Ok(await Mediator.Send(new GetProductByIdQuery(id)));
    }

    //[Authorize(Roles = C.ADMIN)]
    [HttpPost("create", Name = "CreateProduct")]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductsCommand request)
    {
        //var listFotoUrls = new List<CreateProductImageCommand>();
        //if (request.files is not null && request.files.Any())
        //{
        //    foreach (var foto in request.files)
        //    {
        //        var resultImage = await _manageImageService.UploadImage(new ImageData
        //        {
        //            ImageStream = foto.OpenReadStream(),
        //            Nombre = foto.Name
        //        });

        //        var fotoCommand = new CreateProductImageCommand
        //        {
        //            PublicCode = resultImage.PublicId,
        //            Url = resultImage.Url
        //        };

        //        listFotoUrls.Add(fotoCommand);
        //    }
        //    request.ImageUrls = listFotoUrls;
        //}
        var result = await Mediator.Send(request);
        

        return CreatedAtAction(nameof(GetProductById),new { id=result.Value.Id}, result.Value);
    }

    //[Authorize(Roles = C.ADMIN)]
    [HttpPost("createimages", Name = "CreateProductImages")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> CreateProductImages([FromForm] CreateProductImagesCommand request)
    {
        return Ok();
    }

    //[Authorize(Roles = C.ADMIN)]
    [HttpPut("update", Name = "UpdateProduct")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateProduct([FromForm] UpdateProductsCommand request)
    {
        //var listFotoUrls = new List<CreateProductImageCommand>();
        //if (request.files is not null && request.files.Any())
        //{
        //    foreach (var foto in request.files)
        //    {
        //        var resultImage = await _manageImageService.UploadImage(new ImageData
        //        {
        //            ImageStream = foto.OpenReadStream(),
        //            Nombre = foto.Name
        //        });

        //        var fotoCommand = new CreateProductImageCommand
        //        {
        //            PublicCode = resultImage.PublicId,
        //            Url = resultImage.Url
        //        };

        //        listFotoUrls.Add(fotoCommand);
        //    }
        //    request.ImageUrls = listFotoUrls;
        //}
        await Mediator.Send(request);
        return Ok();
    }

    //[Authorize(Roles = C.ADMIN)]
    [HttpDelete("status/{id}", Name = "UpdateStatusProduct")]
    [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductDto>> UpdateStatusProduct(Guid id)
    {
        await Mediator.Send(new DeleteProductsCommand(id));
        return Ok();
    }

    //[Authorize(Roles = C.ADMIN)]
    [HttpDelete("delete/{productId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteProductsCommand(id));
        return Ok();
    }

    //[Authorize(Roles = C.ADMIN)]
    [HttpGet("getproductsbystatus", Name = "GetProductByStatus")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetProductByStatus([FromQuery] GetProductsCountByStatusQuery request)
    {
        return Ok(await Mediator.Send(request));
    }
}

