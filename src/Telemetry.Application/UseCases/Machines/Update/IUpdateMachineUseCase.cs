using Telemetry.Communication.Requests;
using Telemetry.Communication.Responses;

namespace Telemetry.Application.UseCases.Machines.Update;

public interface IUpdateMachineUseCase
{
    Task<MachineResponseJson> Execute(Guid id, MachineRequestJson request);
}
