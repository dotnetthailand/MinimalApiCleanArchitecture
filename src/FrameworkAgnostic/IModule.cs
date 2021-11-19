namespace FrameworkAgnostic;
public interface IRegisterModule
{
    IServiceCollection RegisterModule(IServiceCollection builder);
}
public interface IMapEndpoints
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
public interface IModule : IRegisterModule
{
}

