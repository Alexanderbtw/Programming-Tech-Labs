// See https://aka.ms/new-console-template for more information

using Lab2.Task13.Decorators;
using Lab2.Task13.Entities;
using Lab2.Task4.Entities;

var ws = new WeatherService();
var dws = new WeatherServiceDecorator(ws);

dws.GetWeatherData("Saint-Petersburg", new MyDate(1, 1, 2022));