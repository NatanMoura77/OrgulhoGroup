namespace VortiDex.Exceptions.NotFoundExceptions;

public class TrainerNotFoundException : NotFoundException
{
    private static readonly string _message = "Trainer not found.";

    public TrainerNotFoundException() : base(_message) { }
}
