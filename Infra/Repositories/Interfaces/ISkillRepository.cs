using VortiDex.Model;

namespace VortiDex.Infra.Repositories.Interfaces;

public interface ISkillRepository : IRepository<Skill>
{
    bool Exists(Skill skill);
}