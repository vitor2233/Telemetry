namespace Telemetry.Exception.ExceptionBase;

public abstract class TelemetryException : SystemException
{
    protected TelemetryException(string message) : base(message) { }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
