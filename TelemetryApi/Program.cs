using Azure.Core;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using TelemetryApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MAchineDbContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("Postgres");

    if (!builder.Environment.IsDevelopment())
    {
        var credential = new DefaultAzureCredential();

        var token = credential.GetToken(
            new TokenRequestContext(
                new[] { "https://ossrdbms-aad.database.windows.net/.default" }));

        connString = $"{connString};Password={token}";
    }

    options.UseNpgsql(connString);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();