using ClimaTempo.models;
using ClimaTempo.services;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempo.controllers;

[ApiController]
[Route("/api")]
public class WeatherController : Controller
{
    private readonly IGeoService _geoService;
    private readonly IWeatherService _weatherService;

    public WeatherController(IGeoService geoService, IWeatherService weatherService)
    {
        _geoService = geoService;
        _weatherService = weatherService;
    }
    
    
    //Methods

    [HttpGet("weatherbycity/{city}")]
    public async Task<IActionResult> GetWeather([FromRoute] string city)
    {
        try
        {
            var location = await _geoService.GetCoords(city);
            var weatherData = await _weatherService.GetWeather(location.Latitude, location.Longitude);

            return Ok(weatherData);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("weathercoords")]
    public async Task<IActionResult> GetWeatherByCoords([FromQuery] double lat, [FromQuery] double lon)
    {
        try
        {
            var weatherData = await _weatherService.GetWeather(lat, lon);

            return Ok(weatherData);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }






}