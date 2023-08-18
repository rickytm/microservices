using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Dtos;
using Common.CQRS;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateAttributesHandler : IRequestHandler<CreateAttributesCommand, Result<AttributeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAttributesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    Task<Result<AttributeDto>> IRequestHandler<CreateAttributesCommand, Result<AttributeDto>>.Handle(CreateAttributesCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Core.Attribute
        {
            Id = Guid.NewGuid(),
            CategoryId = request.CategoryId,
            Key = request.Key,
            Value = request.Value,
        };

        _unitOfWork.Repository<Core.Attribute, Guid>().Add(newEntity);
        return Task.FromResult(Result<AttributeDto>.Success(_mapper.Map<AttributeDto>(newEntity)));
    }
}
