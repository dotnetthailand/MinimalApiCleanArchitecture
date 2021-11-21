namespace Customer.Infrastructure.Repositories;

using Agoda.IoC.Core;
using Customer.Application.Repositories;
using Customer.Core.Entities;
using Customer.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Threading;
using System.Threading.Tasks;


[RegisterSingleton(For = typeof(ICustomerRepository))]
public class CustomerRepository : DbRepository<SqliteConnection>, ICustomerRepository
{
    public CustomerRepository(IOptions<CustomerDbOptions> options, ICustomerDbTrace customerDbTrace) : base(options.Value.CustomerDb,trace: customerDbTrace) { }

    public async Task<Customer> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        try
        {
            await InsertAsync<Customer, long>(customer, cancellationToken: cancellationToken);
        }
        catch(Exception ex)
        {
            // Todo: Craeat Custom exception
        }
       
        return customer;
    }
}
