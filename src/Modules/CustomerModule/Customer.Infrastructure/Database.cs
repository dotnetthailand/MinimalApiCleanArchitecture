namespace Customer.Infrastructure;

public static class Database
{
    public static async Task InitialDatabase(SqliteConnection connection)
    {
        await connection.ExecuteNonQueryAsync(
            @"CREATE TABLE IF NOT EXISTS [Customer] 
                    (
                        Id INTEGER PRIMARY KEY
                        , FirstName   VARCHAR
                        , LastName    VARCHAR
                        , CreatedDate DATETIME
                        , LastModifiedDate DATETIME
                    );");
        await connection.ExecuteNonQueryAsync(
            @"CREATE TABLE IF NOT EXISTS [Order] 
                    (
                        Id INTEGER PRIMARY KEY
                        , Number VARCHAR NOT NULL
                        , Description VARCHAR                       
                        , TotalPrice DECIMAL
                        , CustomerId INTEGER NOT NULL
                        , CreatedDate DATETIME
                        , LastModifiedDate DATETIME
                        , FOREIGN KEY(CustomerId) REFERENCES Customer(Id)
                    );");
        await connection.ExecuteNonQueryAsync(
            @"CREATE TABLE IF NOT EXISTS [Product] 
                    (
                        Id INTEGER PRIMARY KEY
	                    , Name VARCHAR NOT NULL
	                    , SKU VARCHAR NOT NULL
	                    , UnitPrice DECIMAL DEFAULT 0 NOT NULL
	                    , CreatedDate DATETIME
	                    , LastModifiedDate DATETIME
                    );");
        await connection.ExecuteNonQueryAsync(
            @"CREATE TABLE IF NOT EXISTS [OrderLine] 
                    (
                        Id INTEGER PRIMARY KEY
	                    , OrderId INTEGER
	                    , ProductId INTEGER
	                    , Price DECIMAL
	                    , CreatedDate DATETIME
	                    , LastModifiedDate DATETIME
                        , FOREIGN KEY(OrderId) REFERENCES [Order](Id)
                        , FOREIGN KEY(ProductId) REFERENCES Product(Id)
                    );");
    }
    public static async Task SeedData(string connectionString)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();
        try
        {
            await InitialDatabase(connection);

            if (await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Customer") == 0)
            {
                // Add Customer
                await connection.InsertAsync<Customer.Core.Entities.Customer>("Customer", new Customer.Core.Entities.Customer
                {
                    FirstName = "Jone",
                    LastName = "Red",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                });
                // Add Order 
                await connection.InsertAsync<Customer.Core.Entities.Order>("[Order]", new Customer.Core.Entities.Order
                {
                    Number = "Order001",
                    Description = "IPhonw Order 001",
                    CustomerId = 1,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                });
                // Add Products
                await connection.InsertAllAsync<Customer.Core.Entities.Product>("Product", new Customer.Core.Entities.Product[]
                  {
                        new Customer.Core.Entities.Product{
                            Name="Samsung s21",
                            SKU="SKU001",
                            UnitPrice= 32000,
                            CreatedDate = DateTime.Now,
                            LastModifiedDate = DateTime.Now,
                        },
                        new Customer.Core.Entities.Product{
                            Name="IPhone 13",
                            SKU="SKU002",
                            UnitPrice= 45000,
                            CreatedDate = DateTime.Now,
                            LastModifiedDate = DateTime.Now,
                        }
                    });
                // Add Order 
                await connection.InsertAsync<Customer.Core.Entities.OrderLine>("OrderLine", new Customer.Core.Entities.OrderLine
                {
                    OrderId = 1,
                    ProductId = 2,
                    Price = 45000,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                });
            }
        }
        catch (Exception ex)
        {
            // TODO: logging here
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}
