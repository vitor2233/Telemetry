using AutoMapper;
using CashFlow.Exception.ExceptionBase;
using Telemetry.Communication.Requests;
using Telemetry.Communication.Responses;
using Telemetry.Domain.Entities;
using Telemetry.Domain.Repositories;
using Telemetry.Domain.Repositories.Machines;
using Telemetry.Exception.ExceptionBase;

namespace Telemetry.Application.UseCases.Machines.Update;

internal class UpdateMachineUseCase : IUpdateMachineUseCase
{
    private readonly IMapper _mapper;
    private readonly IMachinesRepository _MachinesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMachineUseCase(IMapper mapper, IMachinesRepository MachinesRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _MachinesRepository = MachinesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<MachineResponseJson> Execute(Guid id, MachineRequestJson request)
    {
        Validate(request);

        var Machine = await _MachinesRepository.GetById(id);

        if (Machine is null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }

        _mapper.Map(request, Machine);

        _MachinesRepository.Update(Machine);

        await _unitOfWork.Commit();

        return _mapper.Map<MachineResponseJson>(Machine);
    }

    private static void Validate(MachineRequestJson request)
    {
        var validator = new MachineValidator();

        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}