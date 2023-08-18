
using Catalog.Application.Commands;
using Catalog.Core;
using Common.CQRS;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class DeleteBrandsHandler : IRequestHandler<DeleteBrandsCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBrandsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteBrandsCommand request, CancellationToken cancellationToken)
    {
        var found =await  _unitOfWork.Repository<Brand,Guid>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Brand), request.Id);
        _unitOfWork.Repository<Brand,Guid>().Delete(found);     
        return Result.Success();
    }
}
