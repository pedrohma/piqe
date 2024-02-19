using Serilog;
using Microsoft.OpenApi.Models;
using piqe.Core;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
Log.Information("Starting up...");

var builder = WebApplication.CreateBuilder(args);

// Read MySQL connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders(); // Clear other logging providers
    loggingBuilder.AddSerilog(); // Add Serilog as the logging provider
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.MapControllers();

app.Run();