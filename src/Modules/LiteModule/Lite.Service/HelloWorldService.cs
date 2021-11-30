namespace Lite.Service;

[RegisterSingleton]
public class HelloWorldService : IHelloWorldService {}

public interface IHelloWorldService
{
    string SayHello() => "Hello world";
}
