using MediatR;

namespace Catalog.Application.Commands;

public class DeleteVariantsCommand : IRequest
{
    public Guid Id { get; set; }
}
