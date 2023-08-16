
using Catalog.Application.Commands;
using Catalog.Core;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class DeleteCategoriesHandler : IRequestHandler<DeleteCategoriesCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoriesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteCategoriesCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Category, Guid>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Category), request.Id);

        _unitOfWork.Repository<Category,Guid>().Delete(found);
    }
}
