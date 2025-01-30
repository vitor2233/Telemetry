using Telemetry.Domain.Contracts.Mqtt;

namespace Telemetry.Application.UseCases.Location;

internal class SendMachineLocationUseCase : ISendMachineLocationUseCase
{
    public Task Execute(LocationMessage location)
    {
        Console.Write(location);
        throw new NotImplementedException();
    }
}