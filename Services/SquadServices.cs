using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Exceptions.BadRequestExceptions;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Mapper.Interfaces;
using VortiDex.Services.Interface;

namespace VortiDex.Services;

public class SquadServices : ISquadService
{
    private readonly ISquadRepository _squadRep;
    private readonly ISquadMapper _mapper;
    public SquadServices(ISquadRepository squadRep, ISquadMapper mapper)
    {
        _squadRep = squadRep;
        _mapper = mapper;
    }

    public ReadSquadDtoWithRelations Create(CreateSquadDto createDto)
    {
        createDto.Name = createDto.Name.ToUpper();

        var squad = _mapper
            .ToModel(createDto);

        _squadRep
            .CreateRep(squad);

        var readSquad = _mapper
            .ToReadDtoWithRelations(squad);

        return (readSquad);
    }

    public ReadSquadDtoWithRelations ReadById(int squadId)
    {
        var squad = _squadRep
            .FindById(squadId) ?? throw new SquadNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(squad);

        return (dto);
    }

    public ICollection<ReadSquadDto> ReadAll()
    {
        var squad = _squadRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(squad);

        return dto;
    }

    public ReadSquadDtoWithRelations Update(int squadId, UpdateSquadDto updateDto)
    {
        var squad = _squadRep
            .FindById(squadId);

        if (squad is null)
            return Create(
                _mapper
                    .ToCreateDto(updateDto)
            );

        squad.Name = squad.Name.ToUpper();

        squad = _mapper
            .ToExistentModel(updateDto, squad);

        _squadRep
            .UpdateRep(squad);

        var squadDto = _mapper
            .ToReadDtoWithRelations(squad);

        return squadDto;
    }

    public void Delete(int squadId)
    {
        var squad = _squadRep
           .FindById(squadId) ?? throw new SquadNotFoundException();

        _squadRep
            .DeleteRep(squad);

        return;
    }

    public ReadSquadDtoWithRelations DeletePokemonFromSquad(int squadId, int pokemonId)
    {
        var squad = _squadRep
            .FindById(squadId) ?? throw new SquadNotFoundException();

        _squadRep.DeletePokemonFromSquad(squad, pokemonId);

        var squadDto = _mapper
            .ToReadDtoWithRelations(squad);

        return squadDto;
    }

    public ReadSquadDtoWithRelations AddPokemonToSquad(int squadId, int pokemonId)
    {
        var squad = _squadRep
            .FindById(squadId) ?? throw new SquadNotFoundException();

        if(squad.Pokemons.Count > 6)
        {
            throw new BadRequestException("A equipe já está cheia!");
        }

        squad = _squadRep
            .AddPokemonToSquad(squad, pokemonId);

        var squadDto = _mapper
            .ToReadDtoWithRelations(squad);

        return squadDto;
    }
}
