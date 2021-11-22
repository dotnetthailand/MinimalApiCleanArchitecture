namespace FrameworkAgnostic;

public interface IEntryPointMarker { }
public interface IDefineServices
{
    void DefineServices(IServiceCollection builder, IConfiguration configuration);
}
public interface IDefineEndpoints
{
    void DefineEndpoints(IEndpointRouteBuilder endpoints);
}
/// <summary>
/// This class was registerd into IoC with transient lifetime
/// </summary>
public interface IModule : IDefineServices, IDefineEndpoints { }