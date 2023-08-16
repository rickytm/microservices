using MediatR;

namespace Catalog.Application.Commands
{
    public class DeleteBrandsCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
