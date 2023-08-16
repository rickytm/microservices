
using Catalog.Application.Commands;
using Catalog.Core;
using Common.Persistence;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateVariantsHandler : IRequestHandler<CreateVariantsCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVariantsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<Guid> Handle(CreateVariantsCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Variant 
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
        };

        _unitOfWork.Repository<Variant, Guid>().Add(newEntity);

        return Task.FromResult(newEntity.Id);
    }
}
