namespace Telemetry.Communication.Responses;

public class ErrorResponseJson
{
    public List<string> ErrorMessages { get; set; }

    public ErrorResponseJson(string errorMessage)
    {
        ErrorMessages = new List<string> { errorMessage };
    }

    public ErrorResponseJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}