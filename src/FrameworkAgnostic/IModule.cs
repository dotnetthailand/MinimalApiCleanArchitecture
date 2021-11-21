namespace FrameworkAgnostic;

public interface IEntryPointMarker { }

public interface IRegisterModule
{
    void RegisterModule(IServiceCollection builder,IConfiguration configuration );
}
public interface IMapEndpoints
{
    void MapEndpoints(IEndpointRouteBuilder endpoints);
}
public interface IModule : IRegisterModule, IMapEndpoints
{
}