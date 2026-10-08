using bdoProject.Api.Extensions.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddServer(builder.Configuration);

var app = builder.Build();

app.UseApplication();

app.Run();