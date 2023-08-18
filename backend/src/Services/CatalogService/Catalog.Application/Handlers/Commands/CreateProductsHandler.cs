using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Dtos;
using Catalog.Core;
using Common.CQRS;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, Result<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private Product MapProductEntity(CreateProductsCommand request)
    {
        var productEntity = new Product
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Vendedor = request.Vendedor,
            CategoryId = request.CategoryId,
            BrandId = request.BrandId
        };

        return productEntity;
    }
    public Task<Result<ProductDto>> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        var newEntity = MapProductEntity(request);
        if (request.Attributes?.Any() ?? false)
        {
            newEntity.Attributes = request.Attributes.Select(x => new ProductAttribute
            {
                Id = Guid.NewGuid(),
                ProductId = newEntity.Id,
                AttributeId = x.AttributeId,
                CategoryId = x.CategoryId
            }).ToList();
        }

        if (request.Variants?.Any() ?? false)
        {
            newEntity.Variants = request.Variants.Select(x => new ProductVariant
            {
                Id = Guid.NewGuid(),
                ProductId = newEntity.Id,
                VariantId = x.VariantId,
                Precio = x.Precio,
                Stock = x.Stock
            }).ToList();
        }

        _unitOfWork.Repository<Product, Guid>().Add(newEntity);

        return Task.FromResult(Result<ProductDto>.Success(_mapper.Map<ProductDto>(newEntity)));

    }
}
