using Catalog.Application.Commands;
using FluentValidation;

namespace Catalog.Application.Validators;

public class CreateVariantsCommandValidator : AbstractValidator<CreateVariantsCommand>
{
    public CreateVariantsCommandValidator()
    {
        RuleFor(x => x.Nombre)
        .NotEmpty().WithMessage("El nombre es requerido")
        .MinimumLength(5).WithMessage("El nombre debe tener al menos 5 caracteres")
        .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");
    }
}