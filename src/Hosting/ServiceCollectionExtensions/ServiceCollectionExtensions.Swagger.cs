namespace Microsoft.AspNetCore.Builder;

internal static partial class ServiceCollectionExtensions
{
    internal static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwagger();

        return builder;
    }

    internal static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Description = "Minimal API Demo",
                Title = "Minimal API Demo",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "kchinburarat",
                    Url = new Uri("https://github.com/kchinburarat")
                }
            });
        });

        return services;
    }
}

