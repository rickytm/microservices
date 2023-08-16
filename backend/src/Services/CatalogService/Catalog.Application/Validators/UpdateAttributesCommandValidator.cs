using Catalog.Application.Commands;
using FluentValidation;

namespace Catalog.Application.Validators;

public class UpdateAttributesCommandValidator :  AbstractValidator<UpdateAttributesCommand>
{
    public UpdateAttributesCommandValidator() 
    {
        RuleFor(x=> x.Key).NotEmpty().WithMessage("El campo Key no puede ir vacío").MaximumLength(50).WithMessage("El campo Key no debe exceder los 50 caracteres");
        RuleFor(x => x.Value).NotEmpty().WithMessage("El campo Value no puede ir vacío").MaximumLength(50).WithMessage("El campo Value no debe de exceder los 50 caracteres");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("La categoría no puede ir vacía");
    }
}
