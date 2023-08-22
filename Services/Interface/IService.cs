namespace VortiDex.Services.Interface;

public interface IService<Type, CreateDto, UpdateDto, ReadDto, ReadDtoWithRelations>
{
    ReadDtoWithRelations Create(CreateDto createDto);
    ReadDtoWithRelations ReadById(int id);
    ICollection<ReadDto> ReadAll();
    ReadDtoWithRelations Update(int id, UpdateDto updateDto);
    void Delete(int id);
}