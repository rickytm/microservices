using Catalog.Core;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductsCountByStatusQuery : IRequest<int>
{
    public ProductStatus? Status { get; set; }
}
