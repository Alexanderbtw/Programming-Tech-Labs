using Lab2.Task13.Entities;
using Lab2.Task13.Interfaces;
using Lab2.Task4.Entities;

namespace Lab2.Task13.Decorators;

public class WeatherServiceDecorator : IWeatherService
{
    private readonly IWeatherService _weatherService;

    public WeatherServiceDecorator(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    public WeatherData GetWeatherData(string city, MyDate date)
    {
        Console.WriteLine("Getting weather data in the city: " + city + " on the date: " + date);
        Console.WriteLine("Executing time: " + DateTime.Now);
        return _weatherService.GetWeatherData(city, date);
    }
}