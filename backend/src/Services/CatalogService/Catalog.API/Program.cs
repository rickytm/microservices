using AspNetCoreRateLimit;
using Catalog.API.Extensions;
using Catalog.Application;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Data;
using Common.Api.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLocalizationApiServices();
builder.Services.AddConfigDBServices(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddRateLimitServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseMiddleware<ExceptionMiddleware>();
app.UseIpRateLimiting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<Program>();

    try
    {
        var context = service.GetRequiredService<ApplicationDBContext>();

        await context.Database.MigrateAsync();
        await ApplicationDBContextSeedData.InitDb(context, logger);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error en migración");
    }
}

app.Run();
