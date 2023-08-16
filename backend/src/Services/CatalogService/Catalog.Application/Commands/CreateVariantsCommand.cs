using MediatR;

namespace Catalog.Application.Commands;

public class CreateVariantsCommand : IRequest<Guid>
{
    public string Nombre { get; set; }
}
