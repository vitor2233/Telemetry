using System.Net;

namespace Telemetry.Exception.ExceptionBase;

public class ErrorOnValidationException : TelemetryException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    public ErrorOnValidationException(string errorMessage) : base(string.Empty)
    {
        _errors = [errorMessage];
    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
