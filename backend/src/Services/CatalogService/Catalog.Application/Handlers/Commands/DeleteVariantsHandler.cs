﻿
using Catalog.Application.Commands;
using Catalog.Core;
using Common.CQRS;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class DeleteVariantsHandler : IRequestHandler<DeleteVariantsCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVariantsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteVariantsCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Variant,Guid>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Variant), request.Id);
        
        _unitOfWork.Repository<Variant,Guid>().Delete(found);

        return Result.Success();
    }
}
