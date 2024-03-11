using ClimaTempo.models;

namespace ClimaTempo.services;

public interface IGeoService
{
    Task<Location> GetCoords(string cidade);
}