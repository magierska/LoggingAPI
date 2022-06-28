using LoggingAPI.Abstractions;
using LoggingAPI.Filters;
using LoggingAPI.Handlers;
using LoggingAPI.Interfaces;
using LoggingAPI.PostgresDb;
using LoggingAPI.PostgresDb.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add console logging.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ILogsHandler, LogsHandler>();
builder.Services.AddTransient<ILogMessageMapper, LogMessageMapper>();
builder.Services.AddTransient<ILogMessageParser, LogMessageParser>();
builder.Services.AddScoped<ILogMessageDbRepository, LogMessageDbRepository>();

builder.Services.AddDbContext<LoggingContext>(options => 
    options.UseNpgsql($"Host={builder.Configuration["POSTGRES_HOST"]};Database={builder.Configuration["POSTGRES_DB"]};Username={builder.Configuration["POSTGRES_USER"]};Password={builder.Configuration["POSTGRES_PASSWORD"]}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
