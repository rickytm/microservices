using Catalog.Application.Commands;
using Catalog.Core;
using Common.Exceptions;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class UpdateVariantsHandler : IRequestHandler<UpdateVariantsCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVariantsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateVariantsCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Variant,Guid>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Variant), request.Id);

        found.Nombre = request.Nombre;        
    }
}
