using FrameworkAgnostic.Modularity;

namespace FrameworkAgnostic.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public  class ImportAttribute: Attribute , IAutoWireProvider
    {
        public Type[] DependedTypes { get; }
        public ImportAttribute(params Type[] dependedTypes)
        {
            DependedTypes = dependedTypes ?? new Type[0];
        }

        public virtual Type[] GetDependedTypes()
        {
            return DependedTypes;
        }
    }
}
