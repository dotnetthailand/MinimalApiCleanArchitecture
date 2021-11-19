using FrameworkAgnostic.Attributes;
using Hello.Services;

namespace HelloModule.Api;

[Import(typeof(HelloService))]
public class HelloModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/hello", GetHello)
             .Produces<String>(StatusCodes.Status200OK)
             .ProducesValidationProblem()
             .WithName("GetHello")
             .WithTags("Hello Module")
             .WithMetadata(new EndpointNameMetadata("Hello Module"));

        endpoints.MapGet("/exception", GetException)
            .Produces<String>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .WithName("GetException")
            .WithTags("Hello Module")
            .WithMetadata(new EndpointNameMetadata("Hello Exception Module"));

        return endpoints;
    }

    // Table of content in module
    private static IResult GetHello(HttpRequest req, IHelloService helloService)
    {

        throw new FrameworkAgnostic.Common.Exceptions.ValidationException(new List<ValidationFailure> { 
                    new ValidationFailure("c","faile errer message")
                  });


        return Results.Ok(helloService.Hello());
    }
    private static IResult GetException()
    {
        throw new Exception("exception");
    }

}
