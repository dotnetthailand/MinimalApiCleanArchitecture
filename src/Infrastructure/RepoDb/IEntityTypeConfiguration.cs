namespace Infrastructure.RepoDb;

public interface IEntityTypeConfiguration
{
    void Configure(IServiceCollection services);

    void ConfigureHandler(IApplicationBuilder app);
}

