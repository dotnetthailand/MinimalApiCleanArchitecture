var builder = WebApplication.CreateBuilder(args);
// ConfigureServices
builder.AddSerilog();
builder.AddSwagger();

builder.RegisterModules(typeof(HelloModule.Api.HelloModule));

var app = builder.Build();

// Global Exception handler
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure
app.UseSwaggerEndpoints();

app.MapEndpoints();
app.Run();
