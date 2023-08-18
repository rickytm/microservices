using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Application.Queries;
using Catalog.Core;
using Common.Persistence.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Catalog.Application.Handlers.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Repository<Product,Guid>().GetAll()
           .Where(x => x.Id == request.Id)
           .Include(p => p.Brand!)
           .Include(p => p.Category!)
           .Include(p => p.Attributes!)
               .ThenInclude(a => a.Attribute)
           .Include(p => p.Variants)           
           .AsSplitQuery()
           .Select(x => new ProductDto
           {
               Id = x.Id,
               Nombre = x.Nombre,
               Descripcion = x.Descripcion,
               BrandId = x.BrandId,
               BrandNombre = x.Brand!.Nombre,
               CategoryId = x.CategoryId,
               CategoryNombre = x.Category!.Nombre,
               Stock = x.Stock,
               Rating = x.Rating,
               Vendedor = x.Vendedor,               
               Attributes = x.Attributes!.Select(a => new ProductAttributeDto
               {
                   Id = a.Id,
                   ProductId = x.Id,
                   ProductName = x.Nombre,
                   CategoryId = x.CategoryId,
                   CategoryName = x.Category!.Nombre,
                   AttributeId = a.AttributeId,
                   Key = a.Attribute!.Key,
                   Value = a.Attribute!.Value
               }).ToList(),
               Variants = x.Variants!.Select(v => new ProductVariantDto
               {
                   Id = v.Id,
                   ProductId = v.ProductId,
                   VariantId = v.VariantId,
                   Precio = v.Precio,
                   Stock = v.Stock,
                   VariantNombre = v.Variant!.Nombre
               }).ToList(),              
               Status = x.Status
           })
           .FirstOrDefaultAsync();

        return _mapper.Map<ProductDto>(product);
    }
}
