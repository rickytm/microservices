
using MediatR;

namespace Catalog.Application.Commands;

public class CreateCategoriesCommand:IRequest<Guid>
{
    public string Nombre { get; set; }
    public Guid? ParentId { get; set; }
}
