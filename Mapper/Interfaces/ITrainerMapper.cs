using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Dtos.Responses.DtosTrainer;
using VortiDex.Model;

namespace VortiDex.Mapper.Interfaces;

public interface ITrainerMapper : IGeralMapper<Trainer, CreateTrainerDto, UpdateTrainerDto, ReadTrainerDto, ReadTrainerDtoWithRelations>
{
}
