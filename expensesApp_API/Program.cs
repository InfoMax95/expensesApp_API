using NLog.Web;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

string loggerConfig = "log.config";
var logger = NLogBuilder.ConfigureNLog(loggerConfig).GetCurrentClassLogger();

IConfiguration config = builder.Configuration;

// Add services to the container.
builder.Logging.AddEventLog(eventLogSettings =>
{
    eventLogSettings.LogName = "expensesAppAPI";
    eventLogSettings.SourceName = "expensesAppAPI";
});
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Enable CORS policy to do API call
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// use CORS policy that before i've instanced
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
