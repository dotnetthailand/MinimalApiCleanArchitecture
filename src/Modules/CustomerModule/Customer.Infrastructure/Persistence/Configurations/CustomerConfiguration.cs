using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RepoDb.Microsoft.Extensions.DependencyInjection;

namespace Customer.Infrastructure.Persistence.Configurations
{
    public  class CustomerConfiguration: BaseConfiguration<Core.Entities.Customer>
    {
        public override void Configure(IServiceCollection services)
        {
            FluentDefinition.DbType(cus=> cus.Id, System.Data.DbType.Int64);
        }
        public override void ConfigureHandler(IApplicationBuilder app)
        {
           // FluentDefinition
           //     .PropertyHandler(f => f.Name, app.ApplicationServices.GetRequiredService<PersonNameHandler>());
        }
    }
}
