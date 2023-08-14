using Catalog.Application.Commands;
using FluentValidation;

namespace Ecommerce.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductsCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("El {Nombre} no puede ir vacío").MaximumLength(100).WithMessage("El {Nombre} no puede exceder los 50 caracteres");
        RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La {Descripcion} no puede ir vacía").MaximumLength(4000).WithMessage("El {Descripcion} no puede exceder los 50 caracteres");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("El Favor de seleccionar la categoría del producto");
        RuleFor(x => x.BrandId).NotEmpty().WithMessage("El Favor de seleccionar la marca del producto");
    }
}
