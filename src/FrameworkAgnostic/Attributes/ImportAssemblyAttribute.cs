namespace FrameworkAgnostic.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ImportAssemblyAttribute : Attribute, IAutoWireProvider
{
    public Type[] DependedTypes { get; }
    public ImportAssemblyAttribute(params Type[] dependedTypes)
    {
        DependedTypes = dependedTypes ?? new Type[0];
    }

    public virtual Type[] GetDependedTypes()
    {
        return DependedTypes;
    }
}
