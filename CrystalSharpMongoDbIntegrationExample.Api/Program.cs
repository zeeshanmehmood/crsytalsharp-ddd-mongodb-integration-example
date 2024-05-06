using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrystalSharp;
using CrystalSharp.MongoDb.Extensions;
using CrystalSharpMongoDbIntegrationExample.Application.CommandHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
string database = "crystalsharp-mongodb-integration-example";
MongoDbSettings dbSettings = new(dbConnectionString, database);

CrystalSharpAdapter.New(builder.Services)
    .AddCqrs(typeof(CreateCurrencyCommandHandler))
    .AddMongoDb(dbSettings)
    .CreateResolver();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
