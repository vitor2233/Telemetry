using Telemetry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Telemetry.Infra.DataAccess;
internal class TelemetryDbContext : DbContext
{
    public TelemetryDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Machine> Machines { get; set; }
}
