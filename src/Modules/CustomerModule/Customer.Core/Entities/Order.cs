namespace Customer.Core.Entities;

public class Order : AuditableEntity
{
    /// <summary>
    /// In SQLite version 3.0, the rowid is a 64-bit signed integer.
    /// <a href="https://sqlite.org/version3.html#64-bit%20ROWIDs">64-bit ROWID section</a>.
    /// </summary>
    public long Id { get; set; }
    public string? Number { get; set; }
    public string? Description { get; set; }
    public decimal TotalPrice { get; set; }
    public long CustomerId { get; set; }

}
