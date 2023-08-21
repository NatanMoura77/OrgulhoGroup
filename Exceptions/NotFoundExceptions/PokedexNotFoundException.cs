namespace VortiDex.Exceptions.NotFoundExceptions;

public class PokedexNotFoundException : NotFoundException
{
    private static readonly string _message = "Pokedex not found.";
    public PokedexNotFoundException() : base(_message) { }

}

