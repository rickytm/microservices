using Catalog.Application.Commands;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class UpdateAttributesHandler : IRequestHandler<UpdateAttributesCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAttributesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateAttributesCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Core.Attribute,Guid>().GetByIdAsync(request.Id);
        if(found is null)
            throw new NotFoundException(nameof(Core.Attribute), request.Id);

        found.Value = request.Value ??found.Value;
        found.CategoryId = request.CategoryId;
        found.Key = request.Key ?? found.Key;

        _unitOfWork.Repository<Core.Attribute, Guid>().Update(found);
    }
}
