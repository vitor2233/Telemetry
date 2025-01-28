using System.Net;
using Telemetry.Exception.ExceptionBase;

namespace CashFlow.Exception.ExceptionBase;

public class NotFoundException : TelemetryException
{
    public NotFoundException(string message) : base(message) { }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }
}
