using ClimaTempo.models;

namespace ClimaTempo.services;

public class WeatherService : IWeatherService
{
    private string _apiKey = Environment.GetEnvironmentVariable("MyApi:ApiKey");
    private string _units = Environment.GetEnvironmentVariable("MyApi:Units");
    private string _baseUrl = "https://api.openweathermap.org/data/2.5/weather?";
    
    
    
    public async Task<WeatherData> GetWeather(double lat, double lon)
    {
        var url = $"{_baseUrl}lat={lat}&lon={lon}&appid={_apiKey}&units={_units}";

        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao recuperar localizacao: {response.StatusCode}");
            }
            
            var content = await response.Content.ReadFromJsonAsync<OpenWeatherResponse>();
            return new WeatherData
            (
                content.Name,
                content.Main.Temp,
                content.Main.Humidity,
                content.Weather[0].Description
            );
        }
    }
}