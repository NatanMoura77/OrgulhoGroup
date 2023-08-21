using VortiDex.Dtos.Request.DtosSquad;
using VortiDex.Dtos.Responses.DtosSquad;
using VortiDex.Exceptions.NotFoundExceptions;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;

namespace VortiDex.Services;

public class SquadServices
{
    private readonly SquadRepository _squadRep;
    private readonly SquadMapper _mapper;
    public SquadServices(SquadRepository squadRep, SquadMapper mapper)
    {
        _squadRep = squadRep;
        _mapper = mapper;
    }

    public ReadSquadDtoWithRelations CreateServ(CreateSquadDto createDto)
    {
        var squad = _mapper
            .ToModel(createDto);

        _squadRep
            .CreateRep(squad);

        var readSquad = _mapper
            .ToReadDtoWithRelations(squad);

        return (readSquad);
    }

    public ReadSquadDtoWithRelations GetById(int squadId)
    {
        var squad = _squadRep
            .FindById(squadId) ?? throw new SquadNotFoundException();

        var dto = _mapper
            .ToReadDtoWithRelations(squad);

        return (dto);
    }

    public ICollection<ReadSquadDto> GetAllServ()
    {
        var squad = _squadRep
            .GetAllRep();

        var dto = _mapper
            .ToReadDtoCollection(squad);

        return dto;
    }

    public ReadSquadDtoWithRelations UpdateServ(int squadId, UpdateSquadDto updateDto)
    {
        var squad = _squadRep
            .FindById(squadId);

        if (squad is null)
            return CreateServ(
                _mapper
                    .ToCreateDto(updateDto)
            );

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

        _squadRep.DeletePokemonFromSquad(squad ,pokemonId);

        var squadDto = _mapper
            .ToReadDtoWithRelations(squad);

        return squadDto;
    }

    public ReadSquadDtoWithRelations AddPokemonToSquad(int squadId, int pokemonId)
    {
        var squad = _squadRep
            .FindById(squadId) ?? throw new SquadNotFoundException();

        squad = _squadRep
            .AddPokemonToSquad(squad, pokemonId);

        var squadDto = _mapper
            .ToReadDtoWithRelations(squad);

        return squadDto;
    }
}
