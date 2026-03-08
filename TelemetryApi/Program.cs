using Azure.Core;
using Azure.Identity;
using Microsoft.EntityFrameworkCore; // Added this using directive  
using Npgsql;
using System;
using TelemetryApi.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MAchineDbContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("Postgres");

    if (builder.Environment.IsDevelopment())
    {
        
    }
    else
    {
        var credential = new DefaultAzureCredential();

        var token = credential.GetToken(
            new TokenRequestContext(
                new[] { "https://ossrdbms-aad.database.windows.net/.default" }));
        connString = $"{connString};Password={token}";


    }
    var conn = new NpgsqlConnection(connString);
    conn.Open();
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

app.Run();