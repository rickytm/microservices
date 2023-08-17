using MediatR;

namespace Catalog.Application.Commands;

public class DeleteProductsCommand : IRequest
{
    public Guid Id { get; set; }
}
