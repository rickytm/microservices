using MediatR;

namespace Catalog.Application.Commands;

public class CreateAttributesCommand: IRequest<Guid>
{
    public Guid CategoryId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
