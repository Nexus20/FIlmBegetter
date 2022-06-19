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

        CreateMap<MovieDto, MovieViewModel>()
            .ReverseMap();

        CreateMap<MovieDto, MovieToUpdateViewModel>()
            .ReverseMap();
        
        CreateMap<MovieDto, MovieToCreateViewModel>()
            .ReverseMap();

        CreateMap<GenreDto, GenreViewModel>()
            .ReverseMap();
        
        CreateMap<MovieCollectionDto, MovieCollectionViewModel>()
            .ReverseMap();
        
        CreateMap<RatingDto, RatingViewModel>()
            .ReverseMap();

        CreateMap<CommentDto, CommentViewModel>()
            .ReverseMap();

        CreateMap<UserDto, RegistrationViewModel>()
            .ReverseMap()
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email));

        CreateMap<RegistrationResponseDto, RegistrationResponseViewModel>()
            .ReverseMap();

        CreateMap<AuthenticationDto, AuthenticationViewModel>()
            .ReverseMap();
        
        CreateMap<AuthenticationResponseDto, AuthenticationResponseViewModel>()
            .ReverseMap();
    }
}