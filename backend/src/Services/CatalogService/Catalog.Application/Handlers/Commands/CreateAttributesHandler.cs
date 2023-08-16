using Catalog.Application.Commands;
using Common.Persistence;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateAttributesHandler : IRequestHandler<CreateAttributesCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAttributesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(CreateAttributesCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Core.Attribute 
        {
            Id = Guid.NewGuid(),
            CategoryId = request.CategoryId,
            Key = request.Key,
            Value = request.Value,
        };

        _unitOfWork.Repository<Core.Attribute,Guid>().Add(newEntity);

        return newEntity.Id;
    }
}
