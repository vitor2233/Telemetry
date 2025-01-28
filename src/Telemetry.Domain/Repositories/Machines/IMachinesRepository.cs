
using Telemetry.Domain.Entities;

namespace Telemetry.Domain.Repositories.Machines;

public interface IMachinesRepository
{
    public Task Add(Machine Machine);
    public void Update(Machine Machine);
    public Task<bool> Delete(Guid id);
    public Task<Machine?> GetById(Guid id);
}