namespace VortiDex.Dtos.Responses;

public class ErrorDto
{
    public string Message { get; init; }

    public ErrorDto(string message)
    {
        Message = message;
    }
}