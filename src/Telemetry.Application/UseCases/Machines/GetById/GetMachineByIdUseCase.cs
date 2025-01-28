using AutoMapper;
using CashFlow.Exception.ExceptionBase;
using Telemetry.Communication.Responses;
using Telemetry.Domain.Repositories.Machines;

namespace Telemetry.Application.UseCases.Machines.GetById;

internal class GetMachineByIdUseCase : IGetMachineByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IMachinesRepository _MachinesRepository;

    public GetMachineByIdUseCase(IMapper mapper, IMachinesRepository MachinesRepository)
    {
        _mapper = mapper;
        _MachinesRepository = MachinesRepository;
    }

    public async Task<GetMachineByIdResponseJson> Execute(Guid id)
    {
        var Machine = await _MachinesRepository.GetById(id);

        if (Machine is null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

        var MachineResponse = _mapper.Map<GetMachineByIdResponseJson>(Machine);

        return MachineResponse;
    }
}