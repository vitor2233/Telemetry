using Telemetry.Domain.Repositories;
using Telemetry.Domain.Repositories.Machines;
using Telemetry.Infra.DataAccess;
using Telemetry.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telemetry.Infra.Mqtt;
using Telemetry.Infra.WebSockets;
using Telemetry.Domain.Services;

namespace Telemetry.Infra;

public static class DependencyInjectionExtension
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddServices(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Machines
        services.AddScoped<IMachinesRepository, MachinesRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<TelemetryDbContext>(config => config.UseNpgsql(connectionString));
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IMqttService, MqttService>();
        services.AddSingleton<IWebSocketService, WebSocketService>();
    }
}