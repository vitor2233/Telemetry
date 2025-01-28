namespace Telemetry.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}