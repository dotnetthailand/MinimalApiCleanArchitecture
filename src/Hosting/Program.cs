// Feature 1: .NET Top level statement
SqliteBootstrap.Initialize();
var builder = FrameworkHostBuilder.CreateBuilder<EntryPointMarker>(args);
var app = builder.BuildTemplate();
// Seed Customer module data
await Customer.Infrastructure.Database.SeedData(builder.Configuration.GetConnectionString("CustomerDb"));
await app.RunAsync();
