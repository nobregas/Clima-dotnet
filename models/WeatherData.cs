namespace ClimaTempo.models;

public class WeatherData
{
    public string City { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public string Description { get; set; }

    public WeatherData
        (string city, float temperature, float humidity, string description)
    {
        City = city;
        Temperature = temperature;
        Humidity = humidity;
        Description = description;
    }
    
}