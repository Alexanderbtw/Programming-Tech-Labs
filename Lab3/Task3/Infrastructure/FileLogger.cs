using System.IO;
using System.Text;
using System.Timers;
using Task3.Interfaces;

namespace Task3.Infrastructure;

public class FileLogger<T> : ILogger
{
    private static ILogger? _instance;
    private static readonly object _syncRoot = new();
    
    private readonly Timer _timer;
    private StringBuilder _sb = new();
    private string _path;
    
    public string Name => typeof(T).Name!;
    
    protected FileLogger(string path)
    {
        _path = Path.Combine(path, $"{Name}.log");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        if (!File.Exists(_path))
        {
            File.Create(_path).Dispose();
        }

        _timer = new Timer(10000);
        _timer.Elapsed += FlushBufferToFile;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }
    
    public static ILogger GetInstance(string path, out bool isNew) {
        if (_instance == null)
        {
            lock (_syncRoot)
            {
                if (_instance == null)
                {
                    isNew = true;
                    _instance = new FileLogger<T>(path);
                }
            }
        }

        isNew = false;
        return _instance;
    }

    private void FlushBufferToFile(object? source, ElapsedEventArgs? e)
    {
        try
        {
            File.AppendAllText(_path, _sb.ToString());
            _sb.Clear();
        }
        catch(Exception exception)
        {
            Console.WriteLine("Exception: " + exception.Message);
        }
    }
    public void Log(string message)
    {
        _sb.AppendLine($"{Name}Logger ({DateTimeOffset.Now}): {message}");
    }

    ~FileLogger()
    { 
        _timer.Dispose();
        FlushBufferToFile(null, null);
    }
}