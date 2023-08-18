
using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Dtos;
using Catalog.Core;
using Common.CQRS;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateVariantsHandler : IRequestHandler<CreateVariantsCommand, Result<VariantDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateVariantsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public Task<Result<VariantDto>> Handle(CreateVariantsCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Variant 
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
        };

        _unitOfWork.Repository<Variant, Guid>().Add(newEntity);

        return Task.FromResult(Result<VariantDto>.Success(_mapper.Map<VariantDto>(newEntity)));
    }
}
