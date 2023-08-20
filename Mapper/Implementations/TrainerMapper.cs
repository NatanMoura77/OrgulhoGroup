using AutoMapper;
using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Dtos.Responses.DtosTrainer;
using VortiDex.Model;

namespace VortiDex.Mapper.Implementations;

public class TrainerMapper
{
    private readonly IMapper _mapper;

    public TrainerMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Trainer ToModel(CreateTrainerDto dto) =>
        _mapper.Map<Trainer>(dto);

    public Trainer ToModelUp(UpdateTrainerDto dto) =>
        _mapper.Map<Trainer>(dto);

    public Trainer ToExistentModel(UpdateTrainerDto dto, Trainer trainer) =>
        _mapper.Map(dto, trainer);

    public CreateTrainerDto ToCreateDto(UpdateTrainerDto dto) =>
        _mapper.Map<CreateTrainerDto>(dto);

    public ReadTrainerDto ToReadDto(Trainer trainer) =>
        _mapper.Map<ReadTrainerDto>(trainer);

    public ICollection<ReadTrainerDto> ToReadDtoCollection(
        ICollection<Trainer> trainers
    ) => _mapper.Map<ICollection<ReadTrainerDto>>(trainers);

    public ReadTrainerDto ToReadDtoWithRelations(Trainer trainer) =>
        _mapper.Map<ReadTrainerDto>(trainer);

    public ICollection<ReadTrainerDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Trainer> trainers
    ) => _mapper.Map<ICollection<ReadTrainerDtoWithRelations>>(trainers);
}
