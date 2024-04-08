using Task3.Interfaces;

namespace Task3.Infrastructure;

public class ConsoleLogger<T> : ILogger
{
    public static ILogger Instance { get; } = new ConsoleLogger<T>();
    public string Name => typeof(T).Name!;

    public void Log(string message)
    {
        Console.WriteLine("{0}Logger: {1}", Name, message);
    }
}