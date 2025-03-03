using System.Text.Json.Serialization;
using WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Helpers;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    var connectionString = Environment.GetEnvironmentVariable("db_connection_string");

    Console.WriteLine($"Connection string: {connectionString}");

    services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });


    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    var assembly = typeof(Program).Assembly;

    services.AddAutoMapper(assembly);

    // configure DI for application services
    services.AddScoped<IInternService, InternService>();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

app.Run();