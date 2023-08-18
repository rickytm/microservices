using Catalog.Application.Dtos;
using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.Commands;

public sealed record CreateAttributesCommand(Guid CategoryId, string Key, string Value) : ICommand, IRequest<Result<AttributeDto>>;
public sealed record CreateBrandsCommand(string Nombre) : ICommand, IRequest<Result<BrandDto>>;
public sealed record CreateCategoriesCommand(string Nombre, Guid? ParentId) : ICommand, IRequest<Result<CategoryDto>>;
public sealed record CreateProductImageCommand(string Url, int ProductId, string PublicCode);
public sealed record CreateProductImagesCommand(Guid Id, IReadOnlyList<IFormFile> Files, IReadOnlyList<CreateProductImageCommand> ImageUrls);
public sealed record CreateProductsCommand(string Nombre,
        string Descripcion,
        string Vendedor,
        Guid CategoryId,
        Guid BrandId,
        IReadOnlyList<ProductAttributeDto> Attributes,
        IReadOnlyList<ProductVariantDto> Variants) : ICommand, IRequest<Result<ProductDto>>;

public sealed record CreateVariantsCommand(string Nombre) : ICommand, IRequest<Result<VariantDto>>;
public sealed record DeleteAttributesCommand(Guid Id)  : ICommand, IRequest<Result>;
public sealed record DeleteBrandsCommand(Guid Id) : ICommand, IRequest<Result>;
public sealed record DeleteCategoriesCommand(Guid Id) : ICommand, IRequest<Result>;
public sealed record DeleteProductsCommand(Guid Id) : ICommand, IRequest<Result>;
public sealed record DeleteVariantsCommand(Guid Id) : ICommand, IRequest<Result>;
public sealed record UpdateAttributesCommand(Guid Id, Guid CategoryId, string Key, string Value) : ICommand, IRequest<Result>;
public sealed record UpdateBrandsCommand(Guid Id, string Nombre) : ICommand, IRequest<Result>;
public sealed record UpdateCategoriesCommand(Guid Id, string Nombre, Guid? ParentId) : ICommand, IRequest<Result>;
public sealed record UpdateProductsCommand(Guid Id, string Nombre, string Descripcion, 
    string Vendedor, 
    Guid CategoryId, 
    Guid BrandId, 
    bool RemoveOldImages, 
    IReadOnlyList<IFormFile> Files, 
    IReadOnlyList<object> Ftos, 
    IReadOnlyList<ProductVariantDto> ProductVariants, 
    IReadOnlyList<ProductAttributeDto> ProductAttributes) : ICommand, IRequest<Result>;
public sealed record UpdateVariantsCommand(Guid Id, string Nombre) : ICommand, IRequest<Result>;
