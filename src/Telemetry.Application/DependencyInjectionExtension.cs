using Telemetry.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Telemetry.Application.UseCases.Machines.Register;
using Telemetry.Application.UseCases.Machines.GetById;
using Telemetry.Application.UseCases.Machines.Update;
using Telemetry.Application.UseCases.Machines.Delete;

namespace Telemetry.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        //Machines
        services.AddScoped<IRegisterMachineUseCase, RegisterMachineUseCase>();
        services.AddScoped<IGetMachineByIdUseCase, GetMachineByIdUseCase>();
        services.AddScoped<IUpdateMachineUseCase, UpdateMachineUseCase>();
        services.AddScoped<IDeleteMachineUseCase, DeleteMachineUseCase>();
    }
}