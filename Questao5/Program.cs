using FluentAssertions.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Questao5.Application.AutoMapper;
using Questao5.Domain.Language;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.CrossCutting;
using Questao5.Infrastructure.Database.Context;
using Questao5.Infrastructure.Database.Repository;
using Questao5.Infrastructure.Database.Uow;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Configuration.AddJsonFile("appsettings.json", true, true)
                    .SetBasePath(environment.ContentRootPath)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();
;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Notificacoes
builder.Services.AddScoped<LNotifications>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ILanguageSystem, LanguageSystem>();

//
builder.Services.AddAutoMapper(typeof(CommandToDomainMappingProfile));

builder.Services.AddTransient(typeof(IBaseConsultRepository<>), typeof(RepositoryConsult<>));

//Add Entity Framework SqlLite
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AplicationContext>(options =>
     options.UseSqlite(connectionString)
     .EnableSensitiveDataLogging()
     .UseLazyLoadingProxies()
     );




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


