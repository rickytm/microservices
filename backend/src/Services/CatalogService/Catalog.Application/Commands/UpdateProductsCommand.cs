using Catalog.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.Commands;

public class UpdateProductsCommand : IRequest
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Vendedor { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public bool RemoveOldImages { get; set; }
    public List<IFormFile> files { get; set; }= new List<IFormFile>();
    public IEnumerable<object> Ftos { get; set; } = new List<object>();    
    public IEnumerable<ProductVariantDto> ProductVariants { get; set; } = new List<ProductVariantDto>();
    public IEnumerable<ProductAttributeDto> ProductAttributes { get; set; } = new List<ProductAttributeDto>();
}