namespace Catalog.API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddLocalizationApiServices(this IServiceCollection services)
        {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:3000", "http://localhost:3007", "http://localhost:3008").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            return services;
        }
    }
}
