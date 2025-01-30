using MediatR;
using Telemetry.Application.Commands;
using Telemetry.Application.UseCases.Location;

namespace Telemetry.Application.Handlers;

public class LocationReceivedCommandHandler : IRequestHandler<LocationReceivedCommand, Unit>
{
    private readonly ISendMachineLocationUseCase _useCase;

    public LocationReceivedCommandHandler(ISendMachineLocationUseCase useCase)
    {
        _useCase = useCase;
    }

    public async Task<Unit> Handle(LocationReceivedCommand request, CancellationToken cancellationToken)
    {
        await _useCase.Execute(request.Location);
        return Unit.Value;
    }
}