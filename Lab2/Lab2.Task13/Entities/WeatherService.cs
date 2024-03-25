using Lab2.Task13.Interfaces;

namespace Lab2.Task13.Entities;

public class WeatherService : IWeatherService
{
    private static string[] _summaries = new []
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
    };

    private static Random _rnd = new Random();

    public WeatherData GetWeatherData(string city)
    {
        return new WeatherData(_rnd.Next(-20, 55), _rnd.Next(0, 101), _rnd.Next(0, 41), _summaries[_rnd.Next(_summaries.Length)]);
    }
}