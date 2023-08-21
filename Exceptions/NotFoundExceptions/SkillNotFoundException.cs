using Microsoft.EntityFrameworkCore.Metadata;

namespace VortiDex.Exceptions.NotFoundExceptions;

public class SkillNotFoundException : NotFoundException
{
    private static readonly string _message = "Skill not found.";

    public SkillNotFoundException() : base(_message) { }
}
