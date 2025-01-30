
using MediatR;
using Telemetry.Domain.Contracts.Mqtt;

namespace Telemetry.Application.Commands;

public class LocationReceivedCommand(LocationMessage location) : IRequest<Unit>
{
    public LocationMessage Location { get; } = location;
}