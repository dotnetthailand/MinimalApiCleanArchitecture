namespace RepoDb.Microsoft.Extensions.DependencyInjection;

public interface IEntityTypeConfiguration
{
    void Configure(IServiceCollection services);

    void ConfigureHandler(IApplicationBuilder app);
}

