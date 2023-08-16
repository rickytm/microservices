using MediatR;

namespace Catalog.Application.Commands;

public class UpdateVariantsCommand : IRequest
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
}