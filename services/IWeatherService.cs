using ClimaTempo.models;

namespace ClimaTempo.services;

public interface IWeatherService
{
    Task<WeatherData> GetWeather(double lat, double lon);

}