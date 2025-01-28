using Telemetry.Communication.Requests;
using FluentValidation;

namespace Telemetry.Application.UseCases.Machines;
public class MachineValidator : AbstractValidator<MachineRequestJson>
{
    public MachineValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .WithMessage("Nome é obrigatório")
            .MaximumLength(100)
            .WithMessage("O nome pode ter no máximo 100 caracteres.");

        RuleFor(e => e.Status)
            .IsInEnum()
            .WithMessage("Status inválido. Deve ser Running, Stopped ou Off.");

        RuleFor(e => e.Latitude)
            .InclusiveBetween(-90, 90)
            .WithMessage("Latitude deve estar entre -90 e 90 graus.");

        RuleFor(e => e.Longitude)
            .InclusiveBetween(-180, 180)
            .WithMessage("Longitude deve estar entre -180 e 180 graus.");
    }
}
