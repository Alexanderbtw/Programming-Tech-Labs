using Lab2.Task13.Entities;
using Lab2.Task4.Entities;

namespace Lab2.Task13.Interfaces;

public interface IWeatherService
{
    public WeatherData GetWeatherData(string city, MyDate date);
}