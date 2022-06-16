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

        CreateMap<GenreDto, GenreViewModel>()
            .ReverseMap();
        
        CreateMap<MovieCollectionDto, MovieCollectionViewModel>()
            .ReverseMap();
        
        CreateMap<RatingDto, RatingViewModel>()
            .ReverseMap();

        CreateMap<CommentDto, CommentViewModel>()
            .ReverseMap();
    }
}