using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL;

public class AutomapperProfile : Profile {

    public AutomapperProfile() {

        CreateMap<Movie, MovieDto>()
            .ForMember(d => d.Genres,
                o => o.MapFrom(s => s.MovieGenres.Select(mg => mg.Genre)))
            .ReverseMap()
            .ForMember(d => d.MovieGenres, o => o.Ignore());
    }
}