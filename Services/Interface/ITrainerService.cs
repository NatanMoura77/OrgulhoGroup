using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Dtos.Responses.DtosTrainer;
using VortiDex.Model;

namespace VortiDex.Services.Interface
{
    public interface ITrainerService : IService<Trainer, CreateTrainerDto, UpdateTrainerDto, ReadTrainerDto, ReadTrainerDtoWithRelations>
    {
    }
}
