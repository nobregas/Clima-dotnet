using ClimaTempo.models;
using ClimaTempo.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<IGeoService, GeoService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
