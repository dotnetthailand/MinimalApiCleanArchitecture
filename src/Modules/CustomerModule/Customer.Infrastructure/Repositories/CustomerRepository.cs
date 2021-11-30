using RepoDb.Extensions;

namespace Customer.Infrastructure.Repositories;

[RegisterSingleton(For = typeof(ICustomerRepository))]
public class CustomerRepository : DbRepository<SqliteConnection>, ICustomerRepository
{
    public CustomerRepository(IOptions<CustomerDbOptions> options, ICustomerDbTrace customerDbTrace) 
        : base(options.Value.CustomerDb, 30, RepoDb.Enumerations.ConnectionPersistency.Instance, trace: customerDbTrace) { }

    public async Task<Core.Entities.Customer?> CreateCustomerAsync(Core.Entities.Customer? customer, CancellationToken cancellationToken = default)
    {
        try
        {
            await InsertAsync<Core.Entities.Customer, long>(customer, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            // Todo: Craeat Custom exception
        }

        return customer;
    }

    public async Task<Core.Entities.Customer?> QueryCustomerByIdAsync(long? id, CancellationToken cancellationToken = default)
    {
        var customers = await QueryAsync<Core.Entities.Customer>(cus => cus.Id == id, cancellationToken: cancellationToken);
        return customers.FirstOrDefault();
    }

    public async Task<Core.Entities.Customer?> QueryCustomerOrderAsync(long? id, long? orderId, CancellationToken cancellationToken = default)
    {
        var resultSets = await QueryMultipleAsync<Core.Entities.Customer, Core.Entities.Order>(
             cus => cus.Id == id,
             order => order.Id == orderId);
        var customer = resultSets.Item1.FirstOrDefault();
        if(customer is not null)
        {
            customer.Orders = resultSets.Item2.AsList();
        }
        return customer;
    }
}
