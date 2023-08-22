namespace VortiDex.Mapper.Interfaces;

public interface IGeralMapper<Type, CreateDto, UpdateDto, ReadDto, ReadDtoWithRelations>
{
    public Type ToModel(CreateDto dto);

    public Type ToModelUp(UpdateDto dto);

    public Type ToExistentModel(UpdateDto dto, Type pokedex);

    public CreateDto ToCreateDto(UpdateDto dto);

    public ReadDtoWithRelations ToReadDtoWithRelations(Type pokedex);

    public ICollection<ReadDto> ToReadDtoCollection(
        ICollection<Type> pokedexs
    );
}