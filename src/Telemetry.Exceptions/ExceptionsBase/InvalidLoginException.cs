
using System.Net;

namespace Telemetry.Exception.ExceptionBase;

public class InvalidLoginException : TelemetryException
{
    public InvalidLoginException() : base("Email e/ou senha inválidos")
    { }
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }
}