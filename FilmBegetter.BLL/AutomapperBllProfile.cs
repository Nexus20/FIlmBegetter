using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.DAL.Entities;
using FilmBegetter.Domain;

namespace FilmBegetter.BLL;

public class AutomapperBllProfile : Profile {

    public AutomapperBllProfile() {

        CreateMap<Movie, MovieDto>()
            .ForMember(d => d.Genres,
                o => o.MapFrom(s => s.MovieGenres.Select(mg => mg.Genre)))
            .ForMember(d => d.MovieCollections,
                o => o.MapFrom(s => s.MovieCollections.Select(mmc => mmc.MovieCollection)))
            .ReverseMap()
            .ForMember(d => d.MovieGenres, o => o.Ignore())
            .ForMember(d => d.MovieCollections, o => o.Ignore());

        CreateMap<Genre, GenreDto>()
            .ReverseMap();

        CreateMap<Comment, CommentDto>()
            .ReverseMap()
            .ForMember(d => d.CommentRatings, o => o.Ignore());

        CreateMap<CommentRatingUser, CommentRatingDto>();

        CreateMap<Rating, RatingDto>()
            .ReverseMap();

        CreateMap<Role, RoleDto>().ReverseMap();
        
        CreateMap<User, UserDto>()
            .ForMember(d => d.Roles, o => 
                o.MapFrom(s => s.UserRoles.Select(ur => ur.Role)))
            .ForMember(d => d.SentFriendRequests,
                o =>
                    o.MapFrom(s => s.SentFriendRequests.Select(r => new FriendRequestDto()
                    {
                        Id = r.Id,
                        UserId = r.RecipientId,
                        User = $"{r.Recipient.Name} {r.Recipient.Surname} {r.Recipient.Email}",
                        Status = r.Status
                    })))
            .ForMember(d => d.ReceivedFriendRequests,
                o =>
                    o.MapFrom(s => s.ReceivedFriendRequests.Where(r => r.Status == FriendRequestStatus.New).Select(r => new FriendRequestDto()
                    {
                        Id = r.Id,
                        UserId = r.SenderId,
                        User = $"{r.Sender.Name} {r.Sender.Surname} {r.Sender.Email}",
                        Status = r.Status
                    })))
            .ForMember(d => d.Friends, o => 
                    o.MapFrom(s => s.ReceivedFriendRequests.Where(r => r.Status == FriendRequestStatus.Accepted).Select(r => r.Sender)))
            .ReverseMap()
            .ForMember(d => d.UserRoles, o => o.Ignore())
            .ForMember(d => d.ReceivedFriendRequests, o => o.Ignore())
            .ForMember(d => d.SentFriendRequests, o => o.Ignore());

        CreateMap<Subscription, SubscriptionDto>()
            .ReverseMap();

        CreateMap<MovieCollection, MovieCollectionDto>()
            .ForMember(d => d.Movies, 
                o => o.MapFrom(s => s.MovieCollections.Select(mmc => mmc.Movie)))
            .ReverseMap()
            .ForMember(d => d.MovieCollections, o => o.Ignore());
    }
}