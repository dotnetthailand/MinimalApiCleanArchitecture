namespace Microsoft.Extensions.DependencyInjection;

internal static partial class ServiceCollectionExtensions
{
    internal static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.SpectreConsole(
                "{Timestamp:HH:mm:ss} [{Level:u4}] {Message:lj}{NewLine}{Exception}",
                minLevel: LogEventLevel.Information)
            .CreateLogger();

        builder.Host.UseSerilog();

        return builder;
    }
}