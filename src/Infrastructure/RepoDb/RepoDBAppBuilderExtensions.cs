namespace Microsoft.Extensions.DependencyInjection;

using Infrastructure.RepoDb;

public static class RepoDBAppBuilderExtensions
{
    private static bool _isCallUseRepoDB = false;
    public static IApplicationBuilder UseRepoDB(this IApplicationBuilder app)
    {
        if (!_isCallUseRepoDB)
        {
            var entityTypeConfigurations = app.ApplicationServices.GetRequiredService<IEnumerable<IEntityTypeConfiguration>>();

            foreach (var entityTypeConfiguration in entityTypeConfigurations)
            {
                entityTypeConfiguration.ConfigureHandler(app);
            }

            _isCallUseRepoDB = true;
        }

        return app;
    }
}

