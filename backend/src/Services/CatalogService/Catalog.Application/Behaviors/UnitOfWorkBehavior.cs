using Common.CQRS;
using Common.Persistence.Contracts;
using MediatR;
using System.Transactions;

namespace Catalog.Application.Behaviors
{
    public sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand where TResponse : ResultBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {  
            var response = await next();
            if (response is ResultBase { IsSuccess: true })
            {
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
                
            return response;
        }
    }
}
