using Financial.Entries.Data.Context;
using Financial.Entries.WebApi.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment}.json", true, true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration(app.Environment);
app.UseSerilogRequestLogging();

app.Run();
