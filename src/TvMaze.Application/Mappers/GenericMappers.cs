using AutoMapper;
using TvMaze.Contracts.Output;
using TvMaze.Domain;

namespace TvMaze.Application.Mappers
{
    public class GenericMappers : Profile
    {
        public GenericMappers()
        {
            //DTO -> MODEL
            CreateMap<CastDto, Cast>(MemberList.Source);
            CreateMap<CharacterDto, Character>(MemberList.Source);
            CreateMap<CountryDto, Country>(MemberList.Source);
            CreateMap<EmbeddedDto, Embedded>(MemberList.Source);
            CreateMap<ExternalsDto, Externals>(MemberList.Source);
            CreateMap<ImageDto, Image>(MemberList.Source);
            CreateMap<LinksDto, Links>(MemberList.Source);
            CreateMap<NetworkDto, Network>(MemberList.Source);
            CreateMap<PersonDto, Person>(MemberList.Source);
            CreateMap<PreviousEpisodeDto, PreviousEpisode>(MemberList.Source);
            CreateMap<RatingDto, Rating>(MemberList.Source);
            CreateMap<ScheduleDto, Schedule>(MemberList.Source);
            CreateMap<SelfDto, Self>(MemberList.Source);
            CreateMap<ShowMainInformationDto, ShowMainInformation>(MemberList.Source);

            //MODEL -> DTO
            CreateMap<Cast, CastDto>(MemberList.Source);
            CreateMap<Character, CharacterDto>(MemberList.Source);
            CreateMap<Country, CountryDto>(MemberList.Source);
            CreateMap<Embedded, EmbeddedDto>(MemberList.Source);
            CreateMap<Externals, ExternalsDto>(MemberList.Source);
            CreateMap<Image, ImageDto>(MemberList.Source);
            CreateMap<Links, LinksDto>(MemberList.Source);
            CreateMap<Network, NetworkDto>(MemberList.Source);
            CreateMap<Person, PersonDto>(MemberList.Source);
            CreateMap<PreviousEpisode, PreviousEpisodeDto>(MemberList.Source);
            CreateMap<Rating, RatingDto>(MemberList.Source);
            CreateMap<Schedule, ScheduleDto>(MemberList.Source);
            CreateMap<Self, SelfDto>(MemberList.Source);
            CreateMap<ShowMainInformation, ShowMainInformationDto>(MemberList.Source);
        }
    }
}
