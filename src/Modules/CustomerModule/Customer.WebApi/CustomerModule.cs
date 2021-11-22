namespace Customer.WebApi;
/// <summary>
/// Application Module
/// </summary>
[ImportAssembly(typeof(Infrastructure.IAssemblyMarker))]
[ImportAssembly(typeof(Application.IAssemblyMarker))]
public class CustomerModule : IModule
{
    /// <summary>
    /// Main module configure services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public void DefineServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Infrastructure.CustomerDbOptions>(
            configuration.GetSection(Infrastructure.CustomerDbOptions.ConnectionStrings));


    }
    /// <summary>
    /// Routing Table for Customer module
    /// </summary>
    /// <param name="endpoints"></param>
    public void DefineEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/create-customer", CreateCustomerEndpoint.CreateNewCustomer)
            .Produces<CreateCustomerResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .WithName("Create Customer")
            .WithTags("Customer Module")
            .WithMetadata(new EndpointNameMetadata("Customer Module: Create Customer"));

    }
}
