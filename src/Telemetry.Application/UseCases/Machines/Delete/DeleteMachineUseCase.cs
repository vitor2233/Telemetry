using AutoMapper;
using CashFlow.Exception.ExceptionBase;
using Telemetry.Application.UseCases.Machines.Delete;
using Telemetry.Communication.Responses;
using Telemetry.Domain.Repositories;
using Telemetry.Domain.Repositories.Machines;

namespace Telemetry.Application.UseCases.Machines.GetById;

internal class DeleteMachineUseCase : IDeleteMachineUseCase
{
    private readonly IMapper _mapper;
    private readonly IMachinesRepository _MachinesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMachineUseCase(IMapper mapper, IMachinesRepository MachinesRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _MachinesRepository = MachinesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var Machine = await _MachinesRepository.Delete(id);

        if (!Machine)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

        await _unitOfWork.Commit();
    }
}