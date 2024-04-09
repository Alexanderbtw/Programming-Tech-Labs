using System.Text;
using Shared;

(string pathFrom, string pathTo) = Shared.Helpers.GetPathsFromConsole();
if (!File.Exists(pathFrom))
{
    Console.WriteLine("File not found");
    return;
}

StreamWriter sw = new StreamWriter(File.Create(pathTo));
try
{
    var sb = new StringBuilder();
    List<string> words = new List<string>();
    
    Helpers.ParseFileBySymbol(pathFrom, 
        symbol =>
        {
            switch (symbol)
            {
                case ' ':
                    words.Insert(0, sb.ToString());
                    sb.Clear();
                    break;
                case '\n':
                case '\r':
                    if (sb.Length > 0)
                    {
                        words.Insert(0, sb.ToString());
                        sw.WriteLine(words.Aggregate((a, b) => a + " " + b));
                    }

                    sb.Clear();
                    words.Clear();
                    break;
                default:
                    sb.Append(symbol);
                    break;
            }
        },
        symbol =>
        {
            if (sb.Length > 0)
            {
                words.Insert(0, sb.ToString());
                sw.WriteLine(words.Aggregate((a, b) => a + " " + b));
            }
        });
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
finally
{ 
    sw.Dispose();
}