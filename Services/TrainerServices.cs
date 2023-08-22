using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Dtos.Responses.DtosTrainer;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Mapper.Interfaces;
using VortiDex.Services.Interface;

namespace VortiDex.Services;

public class TrainerServices : ITrainerService
{
    private readonly ITrainerRepository _trainerRep;
    private readonly ITrainerMapper _mapper;
    public TrainerServices(ITrainerRepository trainerRep, ITrainerMapper mapper)
    {
        _trainerRep = trainerRep;
        _mapper = mapper;
    }

    public ReadTrainerDtoWithRelations Create(CreateTrainerDto createDto)
    {
        var trainer = _mapper
            .ToModel(createDto);

       _trainerRep
            .CreateRep(trainer);

        var readTrainer = _mapper
            .ToReadDtoWithRelations(trainer);
        
        return readTrainer;
    }

    public ReadTrainerDtoWithRelations ReadById(int trainerId)
    {
        var trainer = _trainerRep
            .FindById(trainerId) ?? throw new TrainerNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(trainer);
        
        return (dto);

    }

    public ICollection<ReadTrainerDto> ReadAll()
    {
        var trainer = _trainerRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(trainer);

        return dto;
    }

    public ReadTrainerDtoWithRelations Update(int trainerId, UpdateTrainerDto updateDto)
    {
        var trainer = _trainerRep
            .FindById(trainerId);

        if (trainer is null)
            return Create(
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
