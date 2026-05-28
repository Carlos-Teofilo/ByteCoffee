using OrderingContext.Api.Endpoints;
using OrderingContext.Application.DependencyInjection;
using OrderingContext.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
var rabbitMqConnectionString = builder.Configuration.GetConnectionString("RabbitMqConnection")!;

builder.Services.AddInfrastructure(connectionString, rabbitMqConnectionString);
builder.Services.AddApplication();

var app = builder.Build();

app.MapOrder();

app.Run();
