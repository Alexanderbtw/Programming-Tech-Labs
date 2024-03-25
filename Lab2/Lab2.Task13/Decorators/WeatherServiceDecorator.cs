using Lab2.Task13.Entities;
using Lab2.Task13.Interfaces;

namespace Lab2.Task13.Decorators;

public class WeatherServiceDecorator : IWeatherService
{
    private readonly IWeatherService _weatherService;

    public WeatherServiceDecorator(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    public WeatherData GetWeatherData(string city)
    {
        Console.WriteLine("Getting weather data in the city: " + city);
        Console.WriteLine("Executing time: " + DateTime.Now);
        return _weatherService.GetWeatherData(city);
    }
}