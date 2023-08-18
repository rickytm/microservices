
using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Dtos;
using Catalog.Core;
using Common.CQRS;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateCategoriesHandler : IRequestHandler<CreateCategoriesCommand, Result<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public Task<Result<CategoryDto>> Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Category 
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
            ParentId = request.ParentId,
        };

        _unitOfWork.Repository<Category,Guid>().Add(newEntity);

        return Task.FromResult(Result<CategoryDto>.Success(_mapper.Map<CategoryDto>(newEntity)));
    }
}
