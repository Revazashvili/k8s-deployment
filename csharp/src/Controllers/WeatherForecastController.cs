using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace api.Controllers;

[ApiController]
public class WeatherForecastController : ControllerBase
{
    private static string[] _summaries = {};
    private readonly string _postgresConnection;
    private const string DbName = "Weather";
    private const string DropDbCommand = $"DROP DATABASE IF EXISTS {DbName};";
    private const string CreateDbCommand = $"CREATE DATABASE {DbName};";
    private const string CreateTableCommand = @"CREATE TABLE IF NOT EXISTS Weathers (
              Date TIMESTAMP not null,  
              TemperatureC integer NOT NULL,
              Summary varchar(450) NOT NULL
            )";

    private const string InsertCommand = "INSERT INTO Weathers(Date,TemperatureC,Summary) VALUES (@Date,@TemperatureC,@Summary);";
    
    public WeatherForecastController(IConfiguration configuration)
    {
        _summaries = configuration.GetSection("Summaries").Get<string[]>();
        _postgresConnection = configuration.GetConnectionString("Postgres");
    }

    [HttpGet("/weathers")]
    public IEnumerable<WeatherForecast> Weathers()
    {
        using var connection = new NpgsqlConnection(_postgresConnection);
        return connection.Query<WeatherForecast>("select * from Weathers");
    }

    [HttpGet("/seed")]
    public IActionResult Seed()
    {
        using var connection = new NpgsqlConnection(_postgresConnection);
        var weathers = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]
            })
            .ToList();
        weathers.ForEach(weather =>
        {
            connection.Execute(InsertCommand, new
            {
                weather.Date,
                weather.TemperatureC,
                weather.Summary
            });
        });
        return Ok();
    }
    
    [HttpGet("/setup")]
    public IActionResult CreateDatabaseAndTable()
    {
        using var connection = new NpgsqlConnection(_postgresConnection);
        connection.Execute(DropDbCommand);
        connection.Execute(CreateDbCommand);
        connection.Execute(CreateTableCommand);
        return Ok();
    }
}
