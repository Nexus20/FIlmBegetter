using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.DAL.Entities;

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

        CreateMap<User, UserDto>()
            .ReverseMap();

        CreateMap<Subscription, SubscriptionDto>()
            .ReverseMap();

        CreateMap<MovieCollection, MovieCollectionDto>()
            .ForMember(d => d.Movies, 
                o => o.MapFrom(s => s.MovieCollections.Select(mmc => mmc.Movie)))
            .ReverseMap()
            .ForMember(d => d.MovieCollections, o => o.Ignore());
    }
}