namespace ClimaTempo.models;

public class GeocodingResponse
{
    public string Name { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Country { get; set; }
    public string[] AddressComponents { get; set; } // Optional: Array of address components

    public GeocodingResponse(string name, double lat, double lon, string country, string[] addressComponents = null)
    {
        Name = name;
        Lat = lat;
        Lon = lon;
        Country = country;
        AddressComponents = addressComponents;
    }
}