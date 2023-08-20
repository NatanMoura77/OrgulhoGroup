using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Dtos.Responses.DtosTrainer;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;

namespace VortiDex.Services;

public class TrainerServices
{
    private readonly TrainerRepository _trainerRep;
    private readonly TrainerMapper _mapper;
    public TrainerServices(TrainerRepository trainerRep, TrainerMapper mapper)
    {
        _trainerRep = trainerRep;
        _mapper = mapper;
    }

    public void CreateServ(CreateTrainerDto createDto)
    {
        var trainer = _mapper
            .ToModel(createDto);

        trainer = _trainerRep
            .CreateRep(trainer);

    }

    public void GetById(int trainerId)
    {
        var trainer = _trainerRep
            .FindById(trainerId);
            //?? throw new StudentNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(trainer);
    }

    public ICollection<ReadTrainerDtoWithRelations> GetAllServ()
    {
        var trainer = _trainerRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoWithRelationsCollection(trainer);

        return dto;
    }

    public void UpdateServ(int trainerId, UpdateTrainerDto updateDto)
    {
        var trainer = _trainerRep.FindById(trainerId);

        if (trainer is null)
        {
            CreateServ(_mapper.ToCreateDto(updateDto));
        }
        else
        {
            trainer = _mapper.ToExistentModel(updateDto, trainer);
            _trainerRep.UpdateRep(trainer);
            _mapper.ToReadDtoWithRelations(trainer);
        }
    }

    public void Delete(int trainerId) 
    {
        var trainer = _trainerRep
           .FindById(trainerId);
           //?? throw new StudentNotFoundException();

        _trainerRep
            .DeleteRep(trainer);

        return;
    }
}
