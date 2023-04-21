using GEscolar.API.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Utils;
using Utils.Connections;
using GEscolar.Commands;
using GEscolar.Queries;
using GEscolar.API.Configutarion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var settings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

Variables.DefaultConnection = settings.DefaultConnection;

//Entity
builder.Services.AddDbContext<EscolarDbContext>(options =>
{
    options.UseSqlServer(settings.DefaultConnection);
});

//Identity
builder.Services.AddIdentityConfiguration(builder.Configuration);

//mediatR
builder.Services.AddQueries();
builder.Services.AddCommands();

//Dependency Injection
builder.Services.AddDIConfiguration();

//Json Options
builder.Services.AddControllers().AddJsonOptions(options => 
{ 
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
