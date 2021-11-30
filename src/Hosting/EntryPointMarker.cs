namespace Hosting;
/// <summary>
/// Table of  module
/// </summary>
[ImportAssembly(typeof(CustomerModule))]
[ImportAssembly(typeof(LiteModule))]
public class EntryPointMarker : IEntryPointMarker {}
