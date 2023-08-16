using Catalog.Application.Commands;
using FluentValidation;

namespace Catalog.Application.Validators;

public class CreateCategoriesValidator : AbstractValidator<CreateCategoriesCommand>
{
    public CreateCategoriesValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre no puede ir vacío").MaximumLength(50).WithMessage("El nombre no debe exceder los 50 caracteres");
    }
}
