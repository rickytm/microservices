
using Catalog.Application.Commands;
using FluentValidation;

namespace Catalog.Application.Validators;

public class CreateBrandsCommandValidator: AbstractValidator<CreateBrandsCommand>
{
    public CreateBrandsCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre no puede ir vacío").MaximumLength(50).WithMessage("El Nombre no puede exceder los 50 caracteres");
    }
}
