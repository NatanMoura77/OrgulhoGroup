namespace VortiDex.Exceptions.NotFoundExceptions;

public class PokemonNotFoundException : NotFoundException
{
    private static readonly string _message = "Pokemon not found.";

    public PokemonNotFoundException() : base(_message) { }
}
