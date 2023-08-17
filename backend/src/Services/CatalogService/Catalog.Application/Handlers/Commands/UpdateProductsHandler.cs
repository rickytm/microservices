using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Dtos;
using Catalog.Core;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.Application.Handlers.Commands;

public class UpdateProductsHandler : IRequestHandler<UpdateProductsCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    private Product MapProductEntity(UpdateProductsCommand request)
    {
        var productEntity = new Product
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Vendedor = request.Vendedor,
            CategoryId = request.CategoryId,
            BrandId = request.BrandId
        };

        return productEntity;
    }

    private async Task UpdateProductVariants(UpdateProductsCommand request) 
    {
        var productVariants = await _unitOfWork
                .Repository<ProductVariant, Guid>()
                .GetAsync(predicate: x => x.ProductId == request.Id
                        , orderBy: null
                        , includes: new List<Expression<Func<ProductVariant, object>>> { x => x.Variant });

        var relatedIds = productVariants.Select(x => x.Id).ToList();
        var newIds = request.ProductVariants.Select(x => x.Id).ToList();
        var toRemove = relatedIds.Except(newIds).ToList();

        var productVariantsToRemove = productVariants.Where(x => toRemove.Contains(x.Id));
        _unitOfWork.Repository<ProductVariant, Guid>().DeleteRange(productVariantsToRemove);

        var relatedVariants = productVariants.Where(x => !toRemove.Contains(x.Id));

        foreach (ProductVariantDto productVariantDto in request.ProductVariants)
        {
            if (productVariantDto.Id == Guid.Empty)
            {
                productVariantDto.Id = Guid.NewGuid();
                productVariantDto.ProductId = request.Id;
                _unitOfWork.Repository<ProductVariant, Guid>().Add(_mapper.Map<ProductVariant>(productVariantDto));
            }
            else
            {
                var relatedVariantUpdate = relatedVariants.FirstOrDefault(x => x.Id == productVariantDto.Id);
                relatedVariantUpdate.VariantId = productVariantDto.VariantId;
                relatedVariantUpdate.ProductId = productVariantDto.ProductId;
                relatedVariantUpdate.Precio = productVariantDto.Precio;
                relatedVariantUpdate.Stock = productVariantDto.Stock;
                _unitOfWork.Repository<ProductVariant, Guid>().Update(relatedVariantUpdate);
            }
        }
    }

    private async Task UpdateProductAttributes(UpdateProductsCommand request)
    {
        var productAttributes = await _unitOfWork
                .Repository<ProductAttribute, Guid>()
                .GetAsync(predicate: x => x.ProductId == request.Id
                , orderBy: null
                , includes: new List<Expression<Func<ProductAttribute, object>>> { x => x.Attribute});

        var relatedIds = productAttributes.Select(x => x.Id).ToList();
        var newIds = request.ProductAttributes.Select(x => x.Id).ToList();
        var toRemove = relatedIds.Except(newIds).ToList();

        var productAttributesToRemove = productAttributes.Where(x => toRemove.Contains(x.Id));
        _unitOfWork.Repository<ProductAttribute,Guid>().DeleteRange(productAttributesToRemove);

        var relatedAttributes = productAttributes.Where(x => !toRemove.Contains(x.Id));

        foreach(ProductAttributeDto productAttributeDto in request.ProductAttributes)
        {
            var productAttributeRelated = relatedAttributes.FirstOrDefault(x => x.Id == productAttributeDto.Id);
            if(productAttributeRelated is null)
            {
                var productAttribute = new ProductAttribute
                {
                    Id = Guid.NewGuid(),
                    ProductId = request.Id,
                    AttributeId = productAttributeDto.AttributeId,
                    CategoryId = productAttributeDto.CategoryId
                };
                _unitOfWork.Repository<ProductAttribute,Guid>().Add(productAttribute);
            }
        }
    }

    public async Task Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Product,Guid>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Product), request.Id);
        found = MapProductEntity(request);
        await UpdateProductVariants(request);
        await UpdateProductAttributes(request);
    }
}
