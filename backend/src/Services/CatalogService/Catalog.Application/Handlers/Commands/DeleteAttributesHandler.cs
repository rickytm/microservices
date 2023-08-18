using Catalog.Application.Commands;
using Common.CQRS;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class DeleteAttributesHandler : IRequestHandler<DeleteAttributesCommand,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAttributesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteAttributesCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Core.Attribute,Guid>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Core.Attribute), request.Id);
        _unitOfWork.Repository<Core.Attribute,Guid>().Delete(found);     
        return Result.Success();
    }
}
