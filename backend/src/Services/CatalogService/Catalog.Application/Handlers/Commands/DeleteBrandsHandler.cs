
using Catalog.Application.Commands;
using Catalog.Core;
using Common.Exceptions;
using Common.Persistence;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class DeleteBrandsHandler : IRequestHandler<DeleteBrandsCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBrandsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteBrandsCommand request, CancellationToken cancellationToken)
    {
        var found =await  _unitOfWork.Repository<Brand,Guid>().GetByIdAsync(request.Id);
        if(found is null) 
            throw new NotFoundException(nameof(Brand),request.Id);

        _unitOfWork.Repository<Brand,Guid>().Delete(found);     
    }
}
