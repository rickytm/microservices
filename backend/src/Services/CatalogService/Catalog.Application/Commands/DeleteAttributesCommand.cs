using MediatR;

namespace Catalog.Application.Commands;

public class DeleteAttributesCommand : IRequest
{
    public Guid Id { get; set; }
}
