using System.Globalization;

namespace Customer.Infrastructure.Persistence.PropertyHandler;

[RegisterSingleton(Concrete = true)]
public class DateTimeHandler : IPropertyHandler<string, DateTime>
{
    public DateTime Get(string input, ClassProperty property)
    {
        return DateTime.ParseExact(input, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
    }

    public string Set(DateTime input, ClassProperty property)
    {
        return input.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
