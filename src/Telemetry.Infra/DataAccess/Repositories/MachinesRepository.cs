using Telemetry.Domain.Entities;
using Telemetry.Domain.Repositories.Machines;
using Microsoft.EntityFrameworkCore;

namespace Telemetry.Infra.DataAccess.Repositories;

internal class MachinesRepository : IMachinesRepository
{
    private readonly TelemetryDbContext _context;
    public MachinesRepository(TelemetryDbContext context)
    {
        _context = context;
    }

    public async Task Add(Machine Machine)
    {
        await _context.Machines.AddAsync(Machine);
    }

    public void Update(Machine Machine)
    {
        _context.Machines.Update(Machine);
    }

    public async Task<bool> Delete(Guid id)
    {
        var result = await _context.Machines.FirstOrDefaultAsync(e => e.Id == id);
        if (result is null) return false;

        _context.Machines.Remove(result);
        return true;
    }

    public async Task<Machine?> GetById(Guid id)
    {
        return await _context.Machines.FirstOrDefaultAsync(c => c.Id == id);
    }
}