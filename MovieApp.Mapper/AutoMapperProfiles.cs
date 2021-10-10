namespace MovieApp.Mapper
{
    using AutoMapper;
    using MovieApp.Core.DTOs;
    using MovieApp.Core.DTOs.MediaDtos;
    using MovieApp.Core.DTOs.ScreeningDtos;
    using MovieApp.Core.DTOs.TicketDtos;
    using MovieApp.Core.DTOs.UserDtos;
    using MovieApp.Core.Entities;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Media, MediaDto>();
            CreateMap<MediaDto, Media>();
            CreateMap<Actor, ActorDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<RatingDto, Rating>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();
            CreateMap<AddTicketDto, Ticket>();
            CreateMap<TicketDto, AddTicketDto>();
            CreateMap<AddTicketDto, TicketDto>();
            CreateMap<Screening, ScreeningDto>();
            CreateMap<AddScreeningDto, Screening>();
            CreateMap<Screening, AddScreeningDto>();
            CreateMap<AddScreeningDto, ScreeningDto>();
            CreateMap<AddMediaDto, Media>();
            CreateMap<Media, AddMediaDto>();
            CreateMap<UpdateMediaDto, Media>();
            CreateMap<Screening, GetScreeningDto>();
            CreateMap<Ticket, GetTicketDto>();
            CreateMap<AppUser, ProfileDto>();
            CreateMap<AddActorDto, Actor>();
        }
    }
}
