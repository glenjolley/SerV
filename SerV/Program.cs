using Microsoft.EntityFrameworkCore;
using SerV.DBContexts;
using SerV.Repositories;
using SerV.Repositories.Interfaces;
using SerV.Services;
using SerV.Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add EFCore
// TODO: Refactor this to move it outside of Program.cs

var dbHost = builder.Configuration["DB_HOST"] ?? "localhost";
var dbName = builder.Configuration["DB_NAME"] ?? "servdb";
var dbUser = builder.Configuration["DB_USER"] ?? "serv";
var dbPass = builder.Configuration["DB_PASSWD"];
var dbPort = builder.Configuration["DB_PORT"] ?? "3306";

if (dbPass is null)
{
    throw new Exception("Database password not set in environment variable DB_PASSWD");
}

var connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPass};";
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IAccessCodeRepository, AccessCodeRepository>();
builder.Services.AddScoped<IAccessCodeUsageRepository, AccessCodeUsageRepository>();
builder.Services.AddScoped<ICVRepository, CVRepository>();
builder.Services.AddScoped<ICVService, CVService>();
builder.Services.AddScoped<IAccessCodeService, AccessCodeService>();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply pending migrations at startup, creating the database if it does not already exist
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
