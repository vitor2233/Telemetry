using Telemetry.Communication.Requests;
using Telemetry.Communication.Responses;

namespace Telemetry.Application.UseCases.Machines.Register;

public interface IRegisterMachineUseCase
{
    Task<MachineResponseJson> Execute(MachineRequestJson request);
}
