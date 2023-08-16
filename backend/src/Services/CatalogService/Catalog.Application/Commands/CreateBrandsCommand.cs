using MediatR;

namespace Catalog.Application.Commands
{
    public class CreateBrandsCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
    }
}
