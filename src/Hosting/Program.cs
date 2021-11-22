// Feature 1: .NET Top level statement
SqliteBootstrap.Initialize();
var builder = WebApplication.CreateBuilder(args);
builder.AddSerilog();
builder.AddSwagger();
builder.AddModuleMarker<EntryPointMarker>();
var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSwaggerEndpoints();
app.UseRepoDB();
app.UseEndpointDefinitions();
await Database.SeedData(builder.Configuration.GetConnectionString("CustomerDb"));
await app.RunAsync();
