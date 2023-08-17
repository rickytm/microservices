using Catalog.Application.Commands;
using FluentValidation;
namespace Catalog.Application.Validators;

public class UpdateProductsCommandValidator : AbstractValidator<UpdateProductsCommand>
{
    public UpdateProductsCommandValidator()
    {
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Favor de seleccionar la categoría");
        RuleFor(x => x.BrandId).NotEmpty().WithMessage("Favor de seleccionar la marca   ");
        RuleFor(x => x.Vendedor).NotEmpty().WithMessage("El Vendedor no puede ir vacío").MaximumLength(100).WithMessage("El Vendedor no puede exceder los 100 caracteres");
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre no puede ir vacío").MaximumLength(100).WithMessage("El Nombre no puede exceder los 100 caracteres");
        RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La Descripción no puede ir vacía").MaximumLength(500).WithMessage("El Descripción no puede exceder los 500 caracteres");
    }
}
