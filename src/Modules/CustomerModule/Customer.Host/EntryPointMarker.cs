namespace Customer.Host;

[ImportAssembly(typeof(CustomerModule))]
public class EntryPointMarker : IEntryPointMarker
{
}
