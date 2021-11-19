namespace FrameworkAgnostic.Modularity;
public interface IAutoWireProvider
{
    Type[] GetDependedTypes();
}

