using Common.Api.Middlewares;
using Localization.API.Extensions;
using Localization.API.Extensions.CustomFormatters;
using Localization.Application;
using Localization.Infrastructure;
using Localization.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole().AddConsoleFormatter<CustomTimePrefixingFormatter, CustomWrappingConsoleFormatterOptions>();

builder.Services.AddLocalizationApiServices();
builder.Services.AddConfigDBServices(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

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
        ApplicationDBContextSeedData.InitDb(context, logger);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error en migración");
    }
}

app.Run();
