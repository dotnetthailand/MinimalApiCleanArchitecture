namespace Lite.Api;

public class LiteModule : IModule
{
    /// <summary>
    /// Main module configure services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {       
    }
    /// <summary>
    /// Routing Table for Lite module
    /// </summary>
    /// <param name="endpoints"></param>
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/lite", () => "hello")
            .Produces<string>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .WithName("Hello lite")
            .WithTags("Lite Module")
            .WithMetadata(new EndpointNameMetadata("Lite Module:Hello lite"));

    }
}
