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
        endpoints
            .MapPost("/api/create-customer", CreateCustomerEndpoint.CreateNewCustomer)
            .Produces<CreateCustomerResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .WithName("create-customer")           
            .WithTags("Customer Mudule EndPoints");

        endpoints
            .MapGet("/api/get-customer/{id}", QueryCustomerEndpoint.QueryCustomer)
            .Produces<QueryCustomerResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithName("get-customer")
            .WithTags("Customer Mudule EndPoints");

        endpoints
            .MapGet("/api/get-order/{id}/{orderId}", QueryCustomerOrderEndpoint.QueryCustomerOrder)
            .Produces<QueryCustomerOrderResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithName("get-customer-order")
            .WithTags("Customer Mudule EndPoints");

    }
}
