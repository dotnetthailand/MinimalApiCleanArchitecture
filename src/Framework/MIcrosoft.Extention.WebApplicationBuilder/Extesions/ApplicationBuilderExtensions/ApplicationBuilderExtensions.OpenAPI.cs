namespace Microsoft.AspNetCore.Builder;

public static partial class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerEndpoints(this IApplicationBuilder app, string routePrefix = "")
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            c.RoutePrefix = routePrefix;
        });

        return app;
    }
}