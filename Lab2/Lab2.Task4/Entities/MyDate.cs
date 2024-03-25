using System.Globalization;
using System.Numerics;
using System.Text;

namespace Lab2.Task4.Entities;

public class MyDate
{
    private readonly ushort _day;
    private readonly ushort _month;
    private readonly ushort _year;

    public MyDate(ushort day, ushort month, ushort year)
    {
        _day = day;
        _month = month;
        _year = year;
    }
    
    public static bool operator ==(MyDate date1, MyDate date2)
    {
        return date1._day == date2._day && date1._month == date2._month && date1._year == date2._year;
    }
    
    public static bool operator !=(MyDate date1, MyDate date2)
    {
        return date1._day != date2._day || date1._month != date2._month || date1._year != date2._year;
    }
    
    public static bool operator >(MyDate date1, MyDate date2)
    {
        return date1._year > date2._year || date1._month > date2._month || date1._day > date2._day;
    }

    public static bool operator <(MyDate date1, MyDate date2)
    {
        return date1._year < date2._year || date1._month < date2._month || date1._day < date2._day;
    }
    
    public static bool operator >=(MyDate date1, MyDate date2)
    {
        return date1._year >= date2._year || date1._month >= date2._month || date1._day >= date2._day;
    }
    
    public static bool operator <=(MyDate date1, MyDate date2)
    {
        return date1._year <= date2._year || date1._month <= date2._month || date1._day <= date2._day;
    }

    public static bool TryParse(string shortDate, out MyDate? result, CultureInfo? cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        result = null;
        ushort day = 0, month = 0, year = 0;
        string pattern = cultureInfo.DateTimeFormat.ShortDatePattern;

        var parts = shortDate.Split(cultureInfo.DateTimeFormat.DateSeparator);
        if (parts.Length != 3)
            return false;

        var withoutDubs = pattern.Distinct();
        
        int patternNumber = 0;
        foreach (var ch in withoutDubs)
        {
            switch (ch)
            {
                case 'd':
                    if (!ushort.TryParse(parts[patternNumber++], out day)) return false;
                    break;
                case 'M':
                    if (!ushort.TryParse(parts[patternNumber++], out month)) return false;
                    break;
                case 'y':
                    if (!ushort.TryParse(parts[patternNumber++], out year)) return false;
                    break;
            }
        }
        
        if (month > 12 || day > DateTime.DaysInMonth(year, month))
            return false;
        
        result = new MyDate(day, month, year);
        return true; 
    }

    public override string? ToString()
    {
        ReadOnlySpan<char> pattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        int day = _day, month = _month, year = _year;
        var sb = new StringBuilder();
        
        for (int i = pattern.Length - 1; i >= 0 ; i--)
        {
            
            switch (pattern[i])
            {
                case 'd':
                    if (i == 0 || pattern[i - 1]  is not 'd')
                        sb.Insert(0, day);
                    else 
                    {
                        sb.Insert(0, day % 10);
                        day /= 10;
                    }
                    break;
                case 'M':
                    if (i == 0 || pattern[i - 1] is not 'M')
                        sb.Insert(0, month);
                    else
                    {
                        sb.Insert(0, month % 10);
                        month /= 10;
                    }
                    break;
                case 'y':
                    if (i == 0 || pattern[i - 1] is not 'y')
                        sb.Insert(0, year);
                    else
                    {
                        sb.Insert(0, year % 10);
                        year /= 10;
                    }
                    break;
                default:
                    sb.Insert(0, pattern[i]);
                    break;
            }
        }
        
        return sb.ToString();
    }
}

public record MySimpleDate(int Day, int Month, int Year);