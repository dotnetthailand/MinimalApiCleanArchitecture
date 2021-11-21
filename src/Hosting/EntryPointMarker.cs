using Customer.WebApi;
using FrameworkAgnostic;
using FrameworkAgnostic.Attributes;

namespace Hosting;

// Register Module (by domain main entry point)
[ImportAssembly(typeof(CustomerModule))]
public class EntryPointMarker : IEntryPointMarker
{
}
