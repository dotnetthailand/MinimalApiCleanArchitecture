// Feature 1: ..NET 6 features
SqliteBootstrap.Initialize();
var builder = FrameworkHostBuilder.CreateBuilder<EntryPointMarker>(args);
var app = builder.BuildTemplate();
// Seed Customer module data
await Customer.Infrastructure.Database.SeedData(builder.Configuration.GetConnectionString("CustomerDb"));
await app.RunAsync();
