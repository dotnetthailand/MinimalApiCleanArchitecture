namespace Infrastructure.RepoDb;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration
        where TEntity : class
{
    protected EntityMapFluentDefinition<TEntity> FluentDefinition;
    public BaseConfiguration() => FluentDefinition = FluentMapper.Entity<TEntity>();
    public virtual void Configure(IServiceCollection services) { }
    public virtual void ConfigureHandler(IApplicationBuilder app) { }
}

