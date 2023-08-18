using Catalog.Application.Dtos;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}
