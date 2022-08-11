using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static string[] _summaries = {};
    
    public WeatherForecastController(IConfiguration configuration)
    {
        _summaries = configuration.GetSection("Summaries").Get<string[]>();

        var mongoConnectionString = configuration.GetConnectionString("MongoConnection");
        Console.WriteLine($"Mongo Connection: {mongoConnectionString}");
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        })
        .ToArray();
    }
}
