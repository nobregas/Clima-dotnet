namespace ClimaTempo.models;

public class WeatherDataOpenWeather
{
    public string Name { get; set; }
    public Main Main { get; set; }
    public List<Weather> Weather { get; set; }
}

public class Main
{
    public float Temp { get; set; }
    public float Humidity { get; set; }
}

public class Weather
{
    public string Description { get; set; }
}