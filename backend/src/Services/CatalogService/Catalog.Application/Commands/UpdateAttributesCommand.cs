using MediatR;

namespace Catalog.Application.Commands;

public class UpdateAttributesCommand: IRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
