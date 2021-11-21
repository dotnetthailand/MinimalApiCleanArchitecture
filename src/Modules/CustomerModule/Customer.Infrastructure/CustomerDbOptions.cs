namespace Customer.Infrastructure
{
    public class CustomerDbOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string CustomerDb { get; set; } = String.Empty;
    }
}
