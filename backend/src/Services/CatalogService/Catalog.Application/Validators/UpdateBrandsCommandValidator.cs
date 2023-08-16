
using Catalog.Application.Commands;
using FluentValidation;

namespace Catalog.Application.Validators;

public class UpdateBrandsCommandValidator : AbstractValidator<UpdateBrandsCommand>
{
    public UpdateBrandsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("El Id no puede ir vacío");
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre no puede ir vacío").MaximumLength(50).WithMessage("El Nombre no puede exceder los 50 caracteres");
    }
}