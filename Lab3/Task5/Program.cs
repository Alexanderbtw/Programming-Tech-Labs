using System.Text;

string bd = AppDomain.CurrentDomain.BaseDirectory;
for (int i = 0; i < 4; i++)
    bd = Directory.GetParent(bd)!.FullName;
string baseDir = Path.Combine(bd, "Stuff");

Console.WriteLine("Enter path from: ");
string pathFrom = Console.ReadLine() is var path && !string.IsNullOrEmpty(path) ? path : Path.Combine(baseDir, "text.txt");
Console.WriteLine("Enter path to: ");
string pathTo = Console.ReadLine() is var path2 && !string.IsNullOrEmpty(path2) ? path2 : Path.Combine(baseDir, "result.txt");
// ArgumentException.ThrowIfNullOrEmpty(pathFrom);
// ArgumentException.ThrowIfNullOrEmpty(pathTo);

if (!File.Exists(pathFrom))
{
    Console.WriteLine("File not found");
    return;
}
if (!File.Exists(pathTo))
{
    File.Create(pathTo).Dispose();
}

try
{
    var sb = new StringBuilder();
    List<string> words = new List<string>();
    using (StreamReader sr = new StreamReader(pathFrom))
    using (StreamWriter sw = new StreamWriter(pathTo, false))
    {
        while (true)
        {
            char symbol = (char)sr.Read();
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

            if (sr.EndOfStream)
            {
                words.Insert(0, sb.ToString());
                sw.WriteLine(words.Aggregate((a, b) => a + " " + b));
                break;
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

