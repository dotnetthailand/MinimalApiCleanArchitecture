using FrameworkAgnostic;
using FrameworkAgnostic.Attributes;

namespace Hosting;

[Import(typeof(HelloModule.Api.HelloModule))]
public class EntryPointMarker : IRegisterModule
{
    public IServiceCollection RegisterModule(IServiceCollection builder)
    {
        return builder;
    }
}
