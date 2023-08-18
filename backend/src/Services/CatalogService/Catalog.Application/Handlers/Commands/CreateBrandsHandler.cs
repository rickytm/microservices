using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Dtos;
using Catalog.Core;
using Common.CQRS;
using Common.Persistence.Contracts;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public class CreateBrandsHandler : IRequestHandler<CreateBrandsCommand, Result<BrandDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBrandsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public Task<Result<BrandDto>> Handle(CreateBrandsCommand request, CancellationToken cancellationToken)
    {
        var newEntity = new Brand
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre,
        };

        _unitOfWork.Repository<Brand,Guid>().Add(newEntity);
        return Task.FromResult(Result<BrandDto>.Success(_mapper.Map<BrandDto>(newEntity)));
    }
}
