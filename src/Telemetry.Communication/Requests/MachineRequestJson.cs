using Telemetry.Communication.Enums;

namespace Telemetry.Communication.Requests;

public class MachineRequestJson
{
    public string Name { get; set; } = string.Empty;
    public MachineStatus Status { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}