using Telemetry.Domain.Repositories;

namespace Telemetry.Infra.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly TelemetryDbContext _dbContext;
    public UnitOfWork(TelemetryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}