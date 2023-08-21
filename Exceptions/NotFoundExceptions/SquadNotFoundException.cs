namespace VortiDex.Exceptions.NotFoundExceptions;

public class SquadNotFoundException : NotFoundException
{
    private static readonly string _message = "Squad not found.";

    public SquadNotFoundException() : base(_message) { }
}