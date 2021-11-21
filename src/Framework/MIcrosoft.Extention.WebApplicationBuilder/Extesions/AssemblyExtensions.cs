namespace FrameworkAgnostic.Microsoft.Extensions.DependencyInjection.Extesions;

internal static class AssemblyExtensions
{
    public static IEnumerable<IAutoWireProvider> GetAutoWireProvider(this IModule module)
        => module.GetType().GetAutoWireProvider();

    public static IEnumerable<IAutoWireProvider> GetAutoWireProvider(this Type moduleType)
        => moduleType.GetCustomAttributes().OfType<IAutoWireProvider>();
}
