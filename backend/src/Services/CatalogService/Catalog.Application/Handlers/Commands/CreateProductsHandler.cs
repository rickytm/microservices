using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core;
using Common.Persistence;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, Guid>
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
    public async Task<Guid> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        var product = MapProductEntity(request);
        if (request.Attributes?.Any() ?? false)
        {
            product.Attributes = request.Attributes.Select(x => new ProductAttribute
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                AttributeId = x.AttributeId,
                CategoryId = x.CategoryId
            }).ToList();
        }

        if (request.Variants?.Any() ?? false)
        {
            product.Variants = request.Variants.Select(x => new ProductVariant
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                VariantId = x.VariantId,
                Precio = x.Precio,
                Stock = x.Stock
            }).ToList();
        }

        _unitOfWork.Repository<Product, Guid>().Add(product);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
        if (!result)
            throw new Exception("Error al crear el producto");

        return product.Id;

    }
}
