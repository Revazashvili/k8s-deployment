var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secrets.json");

builder.Services.AddHealthChecks();

builder.Services.AddControllers();

var app = builder.Build();

app.MapHealthChecks("/healthz");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
