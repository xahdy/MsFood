using Cadastro.Domain.Interfaces;
using Cadastro.Infra.Repository;
using Cadastro.Infra;
using Microsoft.EntityFrameworkCore;
using Cadastro.Api.Profiles;
using Cadastro.Api.Tracing;
using ActiveMQ.Artemis.Client.Extensions.DependencyInjection;
using ActiveMQ.Artemis.Client.Extensions.Hosting;
using Cadastro.Infra.Services;

var builder = WebApplication.CreateBuilder(args);
IHostEnvironment env = builder.Environment;

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddDbContext<PostgresDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddActiveMq("filaTeste2", new[] { ActiveMQ.Artemis.Client.Endpoint.Create(host: "localhost", port: 5672, "guest", "guest") })
    .AddAnonymousProducer<MessageProducer>();
builder.Services.AddActiveMqHostedService();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenTelemetry(builder);

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

app.Run();
