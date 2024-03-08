using System.Text.Json;
using ClimaTempo.models;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempo.controllers;

[ApiController]
[Route("/v1/weather")]
public class WeatherController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    //Methods

    [HttpGet]
    public async Task<IActionResult> GetWeather([FromQuery] float lat, [FromQuery] float lon)
    {   
        var httpClient = _httpClientFactory.CreateClient();
        var apiKey = "e24a397830b3805362ffd8626ff99cbe";
        var units = "metric";
        var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units={units}";

        var response = await httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest("Erro ao obter os dados do clima");
        }

        var weatherData = await response.Content.ReadFromJsonAsync<WeatherDataOpenWeather>();
        var weatherDataResponse = new WeatherData
        (
            weatherData.Name,
            weatherData.Main.Temp,
            weatherData.Main.Humidity,
            weatherData.Weather[0].Description
        );

        return Ok(weatherDataResponse);

    }








}