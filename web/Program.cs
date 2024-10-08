using Infrastructure.Data;
using Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
       builder.Services.AddDbContext<AppDbContext>(option =>
            option.UseLazyLoadingProxies().UseOracle(Environment.GetEnvironmentVariable("OracleConnectionString")));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        AddDependency(builder.Services);

        builder.Configuration.AddEnvironmentVariables();
   
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
    }

    public static void AddDependency(IServiceCollection services)
    {
        DependencyContainerRepositories.RegisterRepositories(services);
        DependencyContainerValidators.RegisterValidators(services);
        DependencyContainerService.RegisterServices(services);
    }
}