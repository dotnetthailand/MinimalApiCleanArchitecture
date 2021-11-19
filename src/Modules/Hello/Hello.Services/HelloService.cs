namespace Hello.Services;

[RegisterSingleton]
public class HelloService : IHelloService
{
    public string Hello() => "Hello";
}

public interface IHelloService
{
    public string Hello();
}

