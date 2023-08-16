using MediatR;

namespace Catalog.Application.Commands
{
    public class UpdateBrandsCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
