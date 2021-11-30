namespace Microsoft.AspNetCore.Builder;

public static partial class ApplicationBuilderExtensions
{
    internal static bool isConfigureServices = false;
    public static WebApplicationBuilder AddModuleMarker<TEntryPointMarker>(this WebApplicationBuilder builder)
        where TEntryPointMarker : IEntryPointMarker
    {
        builder.AddModuleMarker(typeof(TEntryPointMarker));
        return builder;
    }

    public static WebApplicationBuilder AddModuleMarker(this WebApplicationBuilder builder,Type entryType)
    {
        if (isConfigureServices) return builder;
        HashSet<Assembly> assemblies = new();       
        assemblies.Add(typeof(FrameworkAgnostic.IAssemblyMarker).Assembly);
        assemblies.Add(typeof(SharedKernel.IAssemblyMarker).Assembly);
        foreach (var dependedModuleType in entryType
                                            .GetAutoWireProvider()
                                            .SelectMany(descriptor => descriptor.GetDependedTypes()))
        {
            builder.RegisterModules(assemblies, dependedModuleType);
        }
        // Add Core Framework
        builder.Services.AutoWireAssembly(assemblies.ToArray(), false);
        builder.Services.AddAutoMapper(assemblies.ToArray());
        builder.Services.AddRepoDB(assemblies.ToArray());

        isConfigureServices = true;
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

            if (module.IsAssignableTo(typeof(IModule)))
            {
                // Ref: https://www.strathweb.com/2019/11/instantiating-an-object-without-using-constructor-in-c/
                var instance = FormatterServices.GetUninitializedObject(module) as IModule;
                instance!.DefineServices(builder.Services, builder.Configuration);
            }
            builder.Services.Add(
                new ServiceDescriptor(
                    typeof(IDefineEndpoints), 
                    module.UnderlyingSystemType, 
                    ServiceLifetime.Transient));
        }
        return builder;
    }

    public static WebApplication UseEndpointDefinitions(this WebApplication app)
    {
        var moduleEndpoints = app.Services.GetRequiredService<IEnumerable<IDefineEndpoints>>();
        foreach (var moduleEndpoint in moduleEndpoints)
        {
            moduleEndpoint.DefineEndpoints(app);
        }
        return app;
    }
    
    private static IEnumerable<Type> DiscoverModules(IEnumerable<Assembly> assembliesToScan)
    {
        if (!assembliesToScan.Any())
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for module.");

        return assembliesToScan
                    .SelectMany(a => a.DefinedTypes)
                    .Where(type => type.IsConcrete() && type.IsAssignableTo(typeof(IModule)))
                    .Select(typeInfo => typeInfo.UnderlyingSystemType);
    }
    
    private static bool IsConcrete(this Type type) => !type.GetTypeInfo().IsAbstract && !type.GetTypeInfo().IsInterface;

}
