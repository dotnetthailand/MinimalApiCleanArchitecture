namespace Customer.WebApi;

[ImportAssembly(typeof(Infrastructure.IAssemblyMaker))]
[ImportAssembly(typeof(Application.IAssemblyMaker))]
public class CustomerModule : IModule
{
    public void RegisterModule(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Infrastructure.CustomerDbOptions>(
            configuration.GetSection(Infrastructure.CustomerDbOptions.ConnectionStrings));


    }
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/create-customer", CreateCustomerEndpoint.CreateNewCustomer)
            .Produces<CreateCustomerResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .WithName("Create Customer")
            .WithTags("Customer Module")
            .WithMetadata(new EndpointNameMetadata("Customer Module: Create Customer"));

    }
}
