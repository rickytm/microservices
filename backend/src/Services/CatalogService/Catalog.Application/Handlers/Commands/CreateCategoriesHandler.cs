
using Catalog.Application.Commands;
using Catalog.Core;
using Common.Persistence;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateCategoriesHandler : IRequestHandler<CreateCategoriesCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoriesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<Guid> Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Category 
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
            ParentId = request.ParentId,
        };

        _unitOfWork.Repository<Category,Guid>().Add(newEntity);

        return Task.FromResult(newEntity.Id);
    }
}
