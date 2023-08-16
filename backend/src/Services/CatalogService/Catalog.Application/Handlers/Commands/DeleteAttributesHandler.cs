using Catalog.Application.Commands;
using Common.Persistence;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class DeleteAttributesHandler : IRequestHandler<DeleteAttributesCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAttributesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteAttributesCommand request, CancellationToken cancellationToken)
    {
        var found = await _unitOfWork.Repository<Core.Attribute,Guid>().GetByIdAsync(request.Id);
        _unitOfWork.Repository<Core.Attribute,Guid>().Delete(found);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        if (!result) throw new Exception("Error al eliminar el atributo");        
    }
}
