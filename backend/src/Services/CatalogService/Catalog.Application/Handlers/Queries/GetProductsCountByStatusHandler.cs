
using Catalog.Application.Queries;
using Catalog.Application.Specifications.Products;
using Catalog.Core;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public class GetProductsCountByStatusHandler : IRequestHandler<GetProductsCountByStatusQuery, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsCountByStatusHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(GetProductsCountByStatusQuery request, CancellationToken cancellationToken)
    {
        var totalProducts = await _unitOfWork.Repository<Product,Guid>().CountAsync(new ProductSpecification(new ProductSpecificationParams { Status = request.Status}));
        return totalProducts;
    }
}
