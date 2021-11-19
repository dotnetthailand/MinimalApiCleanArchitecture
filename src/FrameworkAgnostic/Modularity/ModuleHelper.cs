namespace FrameworkAgnostic.Modularity;

internal static class ModuleHelper
{
    public static HashSet<Assembly> FindAutoWireTypes(this HashSet<Assembly>  assemblies, Type moduleType)
    {
        assemblies.Add(moduleType.GetTypeInfo().Assembly);
        var dependencyDescriptors = moduleType
            .GetCustomAttributes()
            .OfType<IAutoWireProvider>();

        foreach (var descriptor in dependencyDescriptors)
        {
            foreach (var dependedModuleType in descriptor.GetDependedTypes())
            {
                assemblies.Add(dependedModuleType.GetTypeInfo().Assembly);
            }
        }
        return assemblies;
    }
}

