﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Behaviors;
public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

    private readonly ILogger<TRequest> _logger;
    public UnhandledExceptionBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;

    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(e, "Application Request: Sucedió una excepción para el request {Name} {@Request}", requestName, request);
            throw e;
        }
    }
}

