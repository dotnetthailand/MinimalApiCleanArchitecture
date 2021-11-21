using Microsoft.Data.Sqlite;
using RepoDb;

namespace DbHelper.RepoDb.Sqlite.Microsoft
{
    public static class Database
    {

        public static void InitialDatabase(string connectionString)
        {
            var connection = new SqliteConnection(connectionString);

            try
            {
                connection
                    .CreateCustomerTable()
                    .CreateOrderTable()
                    .CreateProductTable()
                    .CreateOrderLineTable();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }
        private static SqliteConnection CreateCustomerTable(this SqliteConnection connection)
        {

            /*
             * Stated here: If the type if 'INTEGER PRIMARY KEY', it is automatically an identity table.
             * No need to explicity specify the 'AUTOINCREMENT' keyword to avoid extra CPU and memory space.
             * Link: https://sqlite.org/autoinc.html
             */
            connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS [Customer] 
                    (
                        Id INTEGER PRIMARY KEY
                        , FirstName   VARCHAR
                        , LastName    VARCHAR
                        , CreatedDate DATETIME
                        , LastModifiedDate DATETIME
                    );");
            return connection;
        }

        private static SqliteConnection CreateOrderTable(this SqliteConnection connection)
        {

            /*
             * Stated here: If the type if 'INTEGER PRIMARY KEY', it is automatically an identity table.
             * No need to explicity specify the 'AUTOINCREMENT' keyword to avoid extra CPU and memory space.
             * Link: https://sqlite.org/autoinc.html
             */
            connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS [Order] 
                    (
                        Id INTEGER PRIMARY KEY,
                        Number VARCHAR NOT NULL, 
                        Description VARCHAR,
                        CreatedDate DATETIME,
                        LastModifiedDate DATETIME,
                        TotalPrice DECIMAL,
                        CustomerId INTEGER NOT NULL,                        
                        FOREIGN KEY(CustomerId) REFERENCES Customer(Id)
                    );");
            return connection;
        }

        private static SqliteConnection CreateProductTable(this SqliteConnection connection)
        {

            /*
             * Stated here: If the type if 'INTEGER PRIMARY KEY', it is automatically an identity table.
             * No need to explicity specify the 'AUTOINCREMENT' keyword to avoid extra CPU and memory space.
             * Link: https://sqlite.org/autoinc.html
             */
            connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS [Product] 
                    (
                        Id INTEGER PRIMARY KEY
	                    Name VARCHAR NOT NULL,
	                    SKU VARCHAR NOT NULL,
	                    UnitPrice DECIMAL DEFAULT 0 NOT NULL,
	                    CreatedDate DATETIME,
	                    LastModifiedDate DATETIME
                    );");
            return connection;
        }

        private static SqliteConnection CreateOrderLineTable(this SqliteConnection connection)
        {

            /*
             * Stated here: If the type if 'INTEGER PRIMARY KEY', it is automatically an identity table.
             * No need to explicity specify the 'AUTOINCREMENT' keyword to avoid extra CPU and memory space.
             * Link: https://sqlite.org/autoinc.html
             */
            connection.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS [Product] 
                    (
                        Id INTEGER PRIMARY KEY
	                    OrderId INTEGER,
	                    ProductId INTEGER,
	                    Price DECIMAL,
	                    CreatedDate DATETIME,
	                    LastModifiedDate DATETIME,
                        FOREIGN KEY(OrderId) REFERENCES [Order](Id),
                        FOREIGN KEY(ProductId) REFERENCES Product(Id)
                    );");
            return connection;
        }

    }
}