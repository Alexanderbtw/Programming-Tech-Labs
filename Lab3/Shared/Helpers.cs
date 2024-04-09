namespace Shared;

public static class Helpers
{
    /// <returns> (From, To) </returns>
    public static (string, string) GetPathsFromConsole(string rootFolder = "Stuff", bool withOutput = true)
    {
        string bd = AppDomain.CurrentDomain.BaseDirectory;
        for (int i = 0; i < 4; i++)
            bd = Directory.GetParent(bd)!.FullName;
        string baseDir = Path.Combine(bd, rootFolder);

        Console.WriteLine("Enter path from: ");
        string pathFrom = Console.ReadLine() is var path && !string.IsNullOrEmpty(path) ? path : Path.Combine(baseDir, "text.txt");
        if (withOutput)
        {
            Console.WriteLine("Enter path to: ");
            string pathTo = Console.ReadLine() is var path2 && !string.IsNullOrEmpty(path2) ? path2 : Path.Combine(baseDir, "result.txt");
            return (pathFrom, pathTo); 
        }
        
        return (pathFrom, "without output"); 
    }

    public static void ParseFileBySymbol(string pathFrom, Action<char> symbolHandler, Action<char>? endOfStreamHandler = null)
    {
        char symbol;
        using (StreamReader sr = new StreamReader(pathFrom))
        {
            do
            {
                symbol = (char)sr.Read();
                symbolHandler(symbol);
            } while (!sr.EndOfStream);
        }
        endOfStreamHandler?.Invoke(symbol);
    }
}