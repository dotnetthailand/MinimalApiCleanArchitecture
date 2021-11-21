namespace Microsoft.Extensions.DependencyInjection;

public static class RepoDBServiceCollectionExtensions
{
    public static IServiceCollection AddRepoDB(this IServiceCollection services, params Assembly[] assembliesToScan)
        => services.AddRepoDB(assembliesToScan.AsEnumerable());

    public static IServiceCollection AddRepoDB(this IServiceCollection services, params Type[] handlerAssemblyMarkerTypes)
        => services.AddRepoDB(handlerAssemblyMarkerTypes.AsEnumerable());

    public static IServiceCollection AddRepoDB(this IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
    {
        foreach (var item in ScanEntityConfigurationClass(assembliesToScan))
        {
            item.Configure(services);
            services.TryAddSingleton(item);
        }
        return services;
    }

    public static IServiceCollection AddRepoDB(this IServiceCollection services, IEnumerable<Type> handlerAssemblyMarkerTypes)
        => services.AddRepoDB(handlerAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly));

    private static IEnumerable<IEntityTypeConfiguration> ScanEntityConfigurationClass(IEnumerable<Assembly> assembliesToScan)
    {

        if (!assembliesToScan.Any())
        {
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for entity configuration.");
        }
        var concretions = assembliesToScan
                .SelectMany(a => a.DefinedTypes)
                .Where(type =>
                        type.IsConcrete() &&
                        type.IsAssignableTo(typeof(IEntityTypeConfiguration)))
                .Select(Activator.CreateInstance)
                .Cast<IEntityTypeConfiguration>();

        return concretions;
    }

    private static bool IsAssignableTo(this Type type, Type baseType) => baseType.IsAssignableFrom(type);

    private static bool IsConcrete(this Type type) => !type.GetTypeInfo().IsAbstract && !type.GetTypeInfo().IsInterface;
}
