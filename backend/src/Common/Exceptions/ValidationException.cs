using FluentValidation.Results;

namespace Common.Exceptions;

public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Errors { get; }
    public ValidationException() : base("Se presentaron uno o más errores de validación")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(g => g.PropertyName, e => e.ErrorMessage).ToDictionary(fg => fg.Key, fg => fg.ToArray());
    }
}
