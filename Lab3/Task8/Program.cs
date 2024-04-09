using Shared;

(string pathFrom, _) = Shared.Helpers.GetPathsFromConsole(withOutput: false);
if (!File.Exists(pathFrom))
{
    Console.WriteLine("File not found");
    return;
}

int evenCount = 0;
int oddCount = 0;
int? dummy = null;
try
{
    Helpers.ParseFileBySymbol(pathFrom, 
        symbol =>
        {
            if (char.IsDigit(symbol))
            {
                dummy = ((dummy ?? 0) * 10) + (symbol - '0');
            }
            else
            {
                if (dummy is null) return;
                if (dummy % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
                dummy = null;
            }
        },
        (symbol) =>
        {
            if (dummy is null) return;
            if (dummy % 2 == 0)
                evenCount++;
            else
                oddCount++;
        });
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

Console.WriteLine($"Even count: {evenCount}, odd count: {oddCount}");