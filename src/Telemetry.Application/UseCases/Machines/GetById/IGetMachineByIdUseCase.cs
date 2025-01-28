using Telemetry.Communication.Responses;

namespace Telemetry.Application.UseCases.Machines.GetById;

public interface IGetMachineByIdUseCase
{
    Task<GetMachineByIdResponseJson> Execute(Guid id);
}
