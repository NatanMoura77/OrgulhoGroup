using AutoMapper;
using VortiDex.Dtos.Request.DtosTrainer;
using VortiDex.Dtos.Responses.DtosTrainer;
using VortiDex.Model;

namespace VortiDex.Mapper.Profiles;

public class TrainerProfile : Profile
{
    public TrainerProfile()
    {
        CreateMap<CreateTrainerDto, Trainer>().ReverseMap();
        CreateMap<UpdateTrainerDto, Trainer>().ReverseMap();
        CreateMap<Trainer, ReadTrainerDto>();
        CreateMap<UpdateTrainerDto, CreateTrainerDto>();

        CreateMap<Trainer, ReadTrainerDtoWithRelations>()
            .ForMember(
                dest => dest.Squads,
                opt => opt.MapFrom(src => src.Squads)).ReverseMap();
    }
}
