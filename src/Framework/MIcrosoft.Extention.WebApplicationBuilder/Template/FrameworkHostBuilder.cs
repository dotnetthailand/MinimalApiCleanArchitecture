namespace FrameworkAgnostic.Microsoft.Extensions.DependencyInjection.Template;

using FrameworkAgnostic.AspNetCore.Middlewares;
public static class FrameworkHostBuilder
{
	public static WebApplicationBuilder CreateBuilder<TEntryPointMarker>(string[] args)
		where TEntryPointMarker : IEntryPointMarker
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.AddSerilog();
		builder.AddSwagger();
		builder.AddModuleMarker(typeof(TEntryPointMarker));

		return builder;
	}

	public static WebApplication BuildTemplate(this WebApplicationBuilder builder)
	{
		var app = builder.Build();
		app.UseMiddleware<GlobalExceptionMiddleware>();
		app.UseSwaggerEndpoints();
		app.UseRepoDB();
		app.UseEndpointDefinitions();
		return app;
	}


}

