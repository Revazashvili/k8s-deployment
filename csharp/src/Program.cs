var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.MapHealthChecks("/healthz");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
