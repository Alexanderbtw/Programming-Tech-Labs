// See https://aka.ms/new-console-template for more information

using System.Globalization;
using Lab2.Task4.Entities;

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
MyDate.TryParse("1/20/2022", out MyDate? date, CultureInfo.GetCultureInfo("en-US")); 
Console.WriteLine(date);