
using Catalog.Application.Commands;
using Catalog.Core;
using Common.CQRS;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class UpdateBrandsHandler : IRequestHandler<UpdateBrandsCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBrandsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateBrandsCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Brand, Guid>().GetByIdAsync(request.Id);

        if(found is null)
            throw new NotFoundException(nameof(Brand), request.Id);

        found.Nombre = request.Nombre;

        return Result.Success();
        
    }
}
