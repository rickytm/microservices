
using MediatR;

namespace Catalog.Application.Commands;

public class DeleteCategoriesCommand: IRequest
{
    public Guid Id { get; set; }
}
