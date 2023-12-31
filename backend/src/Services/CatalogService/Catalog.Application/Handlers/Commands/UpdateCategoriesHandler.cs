﻿using Catalog.Application.Commands;
using Catalog.Core;
using Common.CQRS;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class UpdateCategoriesHandler : IRequestHandler<UpdateCategoriesCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoriesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateCategoriesCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Category, Guid>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Category), request.Id);
        found.Nombre = request.Nombre;
        found.ParentId = request.ParentId ?? found.ParentId;

        _unitOfWork.Repository<Category,Guid>().Update(found);

        return Result.Success();
    }
}
