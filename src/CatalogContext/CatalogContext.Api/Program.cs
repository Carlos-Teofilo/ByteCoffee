using CatalogContext.Api;
using CatalogContext.Api.Endpoints;
using CatalogContext.Application.DependencyInjection;
using CatalogContext.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitMqConnectionString = builder.Configuration.GetConnectionString("RabbitMqConnection");

if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(rabbitMqConnectionString))
    throw new Exception("A connection string não pôde ser carregada. Verifique o local do appsettings.json.");

builder.Services.AddInfrastructure(connectionString, rabbitMqConnectionString);
builder.Services.AddApplication();

var app = builder.Build();
app.UseHttpsRedirection();

app.MapProduct();
app.MapGet("/", () => "Hello World!");

app.Run();
