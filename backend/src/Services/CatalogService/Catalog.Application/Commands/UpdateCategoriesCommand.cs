
using MediatR;

namespace Catalog.Application.Commands;

public class UpdateCategoriesCommand: IRequest
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public Guid? ParentId { get; set; }
}
