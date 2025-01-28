namespace Telemetry.Application.UseCases.Machines.Delete;

public interface IDeleteMachineUseCase
{
    Task Execute(Guid id);
}
