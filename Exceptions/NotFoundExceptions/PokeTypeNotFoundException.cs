namespace VortiDex.Exceptions.NotFoundExceptions;

public class PokeTypeNotFoundException : NotFoundException
{
    private static readonly string _message = "PokeType not found.";

    public PokeTypeNotFoundException() : base(_message) { }
}
