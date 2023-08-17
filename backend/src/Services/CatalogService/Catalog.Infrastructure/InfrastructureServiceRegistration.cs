using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Services;
using Common.Audit;
using Common.Persistence.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<,>), typeof(AsyncRepository<,>));
        services.AddScoped<IAuditService, AuditService>();

        return services;
    }
}
