using Telemetry.Domain.Contracts.Mqtt;

namespace Telemetry.Application.UseCases.Location;

public interface ISendMachineLocationUseCase
{
    Task Execute(LocationMessage location);
}