using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.WEB.Models.FilterModels;
using FilmBegetter.WEB.Models.ViewModels;

namespace FilmBegetter.WEB;

public class AutomapperWebProfile : Profile {

    public AutomapperWebProfile() {

        CreateMap<MovieFilterViewModel, MovieFilterModel>()
            .ReverseMap();
        CreateMap<UserFilterViewModel, UserFilterModel>()
            .ReverseMap();

        CreateMap<MovieDto, MovieViewModel>()
            .ReverseMap();

        CreateMap<MovieDto, MovieToUpdateViewModel>()
            .ReverseMap();
        
        CreateMap<MovieDto, MovieToCreateViewModel>()
            .ReverseMap()
            .ForMember(d => d.Genres, 
                o => o.MapFrom(
                    s => s.Genres.Split(',', StringSplitOptions.None).Select(g => new GenreDto() {
                Id = g
            })));
        
        CreateMap<MovieDto, MovieToUpdateViewModel>()
            .ReverseMap()
            .ForMember(d => d.Genres, 
                o => o.MapFrom(
                    s => s.Genres.Split(',', StringSplitOptions.None).Select(g => new GenreDto() {
                        Id = g
                    })));

        CreateMap<GenreDto, GenreViewModel>()
            .ReverseMap();
        
        CreateMap<MovieCollectionDto, MovieCollectionViewModel>()
            .ReverseMap();

        CreateMap<MovieCollectionDto, MovieCollectionToCreateViewModel>()
            .ReverseMap();

        CreateMap<RatingDto, RatingViewModel>()
            .ReverseMap();

        CreateMap<CommentDto, CommentViewModel>()
            .ReverseMap();

        CreateMap<UserDto, RegistrationViewModel>()
            .ReverseMap()
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email));
        
        CreateMap<UserDto, UserToUpdateViewModel>()
            .ReverseMap()
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email));

        CreateMap<UserDto, UserViewModel>()
            .ReverseMap();

        CreateMap<SubscriptionDto, SubscriptionViewModel>()
            .ReverseMap();

        CreateMap<RegistrationResponseDto, RegistrationResponseViewModel>()
            .ReverseMap();

        CreateMap<AuthenticationDto, AuthenticationViewModel>()
            .ReverseMap();
        
        CreateMap<AuthenticationResponseDto, AuthenticationResponseViewModel>()
            .ReverseMap();
    }
}