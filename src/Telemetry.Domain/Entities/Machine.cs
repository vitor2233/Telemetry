using System.ComponentModel.DataAnnotations.Schema;
using Telemetry.Domain.Enums;

namespace Telemetry.Domain.Entities;

[Table("T_MACHINE")]
public class Machine
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public MachineStatus Status { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}