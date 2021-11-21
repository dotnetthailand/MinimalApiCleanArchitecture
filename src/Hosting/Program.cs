using Hosting;
using RepoDb;
SqliteBootstrap.Initialize();

var builder = WebApplication.CreateBuilder(args);
var dbConnection = builder.Configuration.GetConnectionString("CustomerDb");
builder.AddSerilog();
builder.AddSwagger();
builder.AddModuleMarker<EntryPointMarker>();
var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSwaggerEndpoints();
app.UseRepoDB();
app.UseModuleEndpoints();

// Seed Database
await Database.SeedData(dbConnection);

app.Run();
