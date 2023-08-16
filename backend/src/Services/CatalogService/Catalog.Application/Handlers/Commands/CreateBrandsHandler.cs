using Catalog.Application.Commands;
using Catalog.Core;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateBrandsHandler : IRequestHandler<CreateBrandsCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<Guid> Handle(CreateBrandsCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Brand
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
        };

        _unitOfWork.Repository<Brand,Guid>().Add(newEntity);
        return Task.FromResult(newEntity.Id);
    }
}
