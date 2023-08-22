namespace VortiDex.Infra.Repositories.Interfaces;

public interface IRepository<Type>
{
    Type CreateRep(Type data);
    Type? FindById(int id);
    ICollection<Type> GetAllRep();
    Type UpdateRep(Type data);
    Type DeleteRep(Type data);
    bool Exists(int id);
}