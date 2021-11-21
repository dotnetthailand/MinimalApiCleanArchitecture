namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{

    internal static readonly List<IModule> registeredModules = new();
    internal static bool isConfigureSerices = false;

    public static WebApplicationBuilder AddModuleMarker<TEntryPointMarker>(this WebApplicationBuilder builder)
        where TEntryPointMarker : IEntryPointMarker
    {
        if (isConfigureSerices) return builder;

        HashSet<Assembly> assemblies = new();
        Type entryType = typeof(TEntryPointMarker);
        assemblies.Add(typeof(IFrameworkAgnosticAssemblyMaker).GetTypeInfo().Assembly);
        assemblies.Add(typeof(IShareKernelAssemblyMaker).GetTypeInfo().Assembly);

        foreach (var dependedModuleType in entryType.GetAutoWireProvider().
                                                     SelectMany(descriptor => descriptor.GetDependedTypes()))
        {
            // Register module
            builder.RegisterModules(assemblies, dependedModuleType);
        }
        builder.Services.AutoWireAssembly(assemblies.ToArray(), false);
        builder.Services.AddAutoMapper(assemblies.ToArray());
        builder.Services.AddRepoDB(assemblies.ToArray());

        isConfigureSerices = true;
        return builder;
    }

    public static WebApplicationBuilder RegisterModules(
        this WebApplicationBuilder builder,
        HashSet<Assembly> assemblies,
        params Type[] handlerAssemblyMarkerTypes)
        => builder.RegisterModules(assemblies, handlerAssemblyMarkerTypes.AsEnumerable());

    public static WebApplicationBuilder RegisterModules(
        this WebApplicationBuilder builder,
        HashSet<Assembly> assemblies,
        IEnumerable<Type> handlerAssemblyMarkerTypes)
        => builder.RegisterModules(assemblies, handlerAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));

    public static WebApplicationBuilder RegisterModules(
        this WebApplicationBuilder builder,
        HashSet<Assembly> assemblies,
        IEnumerable<Assembly> assembliesToScan)
    {
        var modules = DiscoverModules(assembliesToScan);
        foreach (var module in modules)
        {
            foreach (var dependedModuleType in module.GetAutoWireProvider().
                                                      SelectMany(descriptor => descriptor.GetDependedTypes()))
            {
                assemblies.Add(dependedModuleType.GetTypeInfo().Assembly);
            }
            module.RegisterModule(builder.Services, builder.Configuration);
            registeredModules.Add(module);
        }
        return builder;
    }

    public static WebApplication UseModuleEndpoints(this WebApplication app)
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
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for module.");

        var concretions =
            assembliesToScan
                    .SelectMany(a => a.DefinedTypes)
                    .Where(type => type.IsConcrete() && type.IsAssignableTo(typeof(IModule)))
                    .Select(Activator.CreateInstance)
                    .Cast<IModule>();

        return concretions;
    }

    private static bool IsConcrete(this Type type) => !type.GetTypeInfo().IsAbstract && !type.GetTypeInfo().IsInterface;

}
