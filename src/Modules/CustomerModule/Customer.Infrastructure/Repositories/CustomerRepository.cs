namespace Customer.Infrastructure.Repositories;

[RegisterSingleton(For = typeof(ICustomerRepository))]
public class CustomerRepository : DbRepository<SqliteConnection>, ICustomerRepository
{
    public CustomerRepository(IOptions<CustomerDbOptions> options, ICustomerDbTrace customerDbTrace) : base(options.Value.CustomerDb,trace: customerDbTrace) { }

    public async Task<Core.Entities.Customer> CreateCustomerAsync(Core.Entities.Customer customer, CancellationToken cancellationToken = default)
    {
        try
        {
            await InsertAsync<Core.Entities.Customer, long>(customer, cancellationToken: cancellationToken);
        }
        catch(Exception ex)
        {
            // Todo: Craeat Custom exception
        }
       
        return customer;
    }
}
