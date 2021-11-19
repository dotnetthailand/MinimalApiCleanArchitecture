namespace Microsoft.AspNetCore.Builder;

using FrameworkAgnostic;
using FrameworkAgnostic.Modularity;

public static class ModuleExtensions
{

    public static WebApplicationBuilder AddModuleMaker<TEntryPointMarker>(this WebApplicationBuilder builder) where TEntryPointMarker : IRegisterModule
    {
        builder.RegisterModules(typeof(TEntryPointMarker));
        return builder;
    }



    static readonly List<IModule> registeredModules = new();
    static bool isConfigureSerices = false;
    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder, params Type[] handlerAssemblyMarkerTypes)
        => builder.RegisterModules(handlerAssemblyMarkerTypes.AsEnumerable());

    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder, IEnumerable<Type> handlerAssemblyMarkerTypes)
        => builder.RegisterModules(handlerAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));

    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder, IEnumerable<Assembly> assembliesToScan)
    {
        if (isConfigureSerices) return builder;
        HashSet<Assembly> assemblies = new();
        // Register Core
        assemblies.Add(typeof(IFrameworkAgnosticAssemblyMaker).GetTypeInfo().Assembly);

        var modules = DiscoverModules(assembliesToScan);
        foreach (var module in modules)
        {
            assemblies.FindAutoWireTypes(module.GetType());
            module.RegisterModule(builder.Services);
            registeredModules.Add(module);
        }
        builder.Services.AutoWireAssembly(assemblies.ToArray(), false);
        isConfigureSerices = true;
        return builder;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in registeredModules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }

    private static IEnumerable<IModule> DiscoverModules(IEnumerable<Assembly> assembliesToScan)
    {
        if (!assembliesToScan.Any())
        {
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for module.");
        }
        var concretions = assembliesToScan
                    .SelectMany(a => a.DefinedTypes)
                    .Where(type =>
                            type.IsConcrete() &&
                            type.IsAssignableTo(typeof(IModule)))
                    .Select(Activator.CreateInstance)
                     .Cast<IModule>();

        return concretions;
    }

    private static bool IsConcrete(this Type type) => !type.GetTypeInfo().IsAbstract && !type.GetTypeInfo().IsInterface;
}