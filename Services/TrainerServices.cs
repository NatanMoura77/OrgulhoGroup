using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Dtos.Responses.DtosTrainer;
using VortiDex.Exceptions.NotFoundExceptions;
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

    public ReadTrainerDtoWithRelations CreateServ(CreateTrainerDto createDto)
    {
        var trainer = _mapper
            .ToModel(createDto);

       _trainerRep
            .CreateRep(trainer);

        var readTrainer = _mapper
            .ToReadDtoWithRelations(trainer);
        
        return readTrainer;
    }

    public ReadTrainerDtoWithRelations GetById(int trainerId)
    {
        var trainer = _trainerRep
            .FindById(trainerId) ?? throw new TrainerNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(trainer);
        
        return (dto);

    }

    public ICollection<ReadTrainerDtoWithRelations> GetAllServ()
    {
        var trainer = _trainerRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoWithRelationsCollection(trainer);

        return dto;
    }

    public ReadTrainerDtoWithRelations UpdateServ(int trainerId, UpdateTrainerDto updateDto)
    {
        var trainer = _trainerRep
            .FindById(trainerId);

        if (trainer is null)
            return CreateServ(
                _mapper
                    .ToCreateDto(updateDto)
            );

        trainer = _mapper
            .ToExistentModel(updateDto, trainer);

        _trainerRep
            .UpdateRep(trainer);

        var trainerDto = _mapper
            .ToReadDtoWithRelations(trainer);

        return trainerDto;
    }

    public void Delete(int trainerId) 
    {
        var trainer = _trainerRep
           .FindById(trainerId) ?? throw new TrainerNotFoundException();

        _trainerRep
            .DeleteRep(trainer);

        return;
    }
}
