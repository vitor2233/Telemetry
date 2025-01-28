
using AutoMapper;
using Telemetry.Communication.Requests;
using Telemetry.Communication.Responses;
using Telemetry.Domain.Entities;

namespace Telemetry.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        //Machines
        CreateMap<MachineRequestJson, Machine>();
    }

    private void EntityToResponse()
    {
        //Machines
        CreateMap<Machine, MachineResponseJson>();
        CreateMap<Machine, GetMachineByIdResponseJson>();
    }
}