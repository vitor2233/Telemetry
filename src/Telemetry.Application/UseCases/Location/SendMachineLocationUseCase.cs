using Microsoft.Extensions.DependencyInjection;
using Telemetry.Domain.Contracts.Mqtt;
using Telemetry.Domain.Services;

namespace Telemetry.Application.UseCases.Location;

internal class SendMachineLocationUseCase : ISendMachineLocationUseCase
{
    private readonly IServiceProvider _serviceProvider;

    public SendMachineLocationUseCase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task Execute(LocationMessage location)
    {
        var webSocketService = _serviceProvider.GetRequiredService<IWebSocketService>();
        await webSocketService.SendToClientsAsync(location);
    }
}