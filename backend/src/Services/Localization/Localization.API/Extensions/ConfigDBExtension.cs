using Localization.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Localization.API.Extensions
{
    public static class ConfigDbExtension
    {
        public static IServiceCollection AddConfigDBServices(this IServiceCollection services, IConfiguration configuration, bool IsDevelopment)
        {
            var log = services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
            string connString;
            if (IsDevelopment)
            {
                connString = configuration.GetConnectionString("ConnectionString")!;
                log.LogInformation($"Connection string development: {connString}");
            }
            else if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_URL")))
            {
                // Use connection string provided at runtime by FlyIO.
                var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL")!;
                log.LogInformation($"Connection string DATABASE_URL: {connUrl}");

                // Parse connection URL to connection string for Npgsql
                connUrl = connUrl.Replace("postgres://", string.Empty);
                var pgUserPass = connUrl.Split("@")[0];
                var pgHostPortDb = connUrl.Split("@")[1];
                var pgHostPort = pgHostPortDb.Split("/")[0];
                var pgDb = pgHostPortDb.Split("/")[1].Split("?")[0];
                var pgUser = pgUserPass.Split(":")[0];
                var pgPass = pgUserPass.Split(":")[1];
                var pgHost = pgHostPort.Split(":")[0];
                var pgPort = pgHostPort.Split(":")[1];
                var updatedHost = pgHost.Replace("flycast", "internal");

                connString = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};SSL Mode=Disable";
                log.LogInformation($"Connection string production: {connString}");
            }
            else
            {
                log.LogInformation($"DATABASE_URL is null or empty");
                connString = configuration.GetConnectionString("ConnectionString")!;
                log.LogInformation($"Connection string production : {connString}");
            }

            services.AddDbContext<ApplicationDBContext>(optionsBuilder =>
            {
                optionsBuilder.UseNpgsql(connString,
                b => b
                    .EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorCodesToAdd: new List<string>() { "DeadlockDetected" }
                    )
                    .MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName));

                // Agrega un logger para registrar los comandos SQL
                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder
                        .AddConsole()
                        .SetMinimumLevel(LogLevel.Debug);
                });
                optionsBuilder.UseLoggerFactory(loggerFactory);

                optionsBuilder.LogTo(
                    filter: (eventId, level) => eventId.Id == CoreEventId.ExecutionStrategyRetrying,
                    logger: (eventData) =>
                    {
                        var retryEventData = eventData as ExecutionStrategyEventData;
                        if (retryEventData != null)
                        {
                            var exceptions = retryEventData.ExceptionsEncountered;
                            Console.WriteLine($"Retry #{exceptions.Count} with delay {retryEventData?.Delay} due to error: {exceptions.Last().Message}");
                        }
                    }
                );
            });

            return services;
        }
    }
}
