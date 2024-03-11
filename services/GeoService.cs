using ClimaTempo.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace ClimaTempo.services;

public class GeoService: IGeoService
{
    private const string _baseUrl = "https://api.openweathermap.org/geo/1.0/direct?q=";
    private string _apiKey = "e24a397830b3805362ffd8626ff99cbe";
    
    public async Task<Location> GetCoords(string cidade)
    {
        var url = $"{_baseUrl}{cidade}&appid={_apiKey}";

        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao recuperar localização: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var locations = JsonConvert.DeserializeObject<List<GeoCodingResponse>>(content);

            try
            {
                return new Location(
                    locations[0].lat,
                    locations[0].lon
                );
            }
            catch (Exception e)
            {

                throw new Exception($"Localização não encontrada para a cidade '{cidade}'");
            }
        }
    }
}
