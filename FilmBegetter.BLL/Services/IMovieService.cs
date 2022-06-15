using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;

namespace FilmBegetter.BLL.Services; 

public interface IMovieService {

    Task CreateMovieAsync(MovieDto dto);
    
    Task UpdateMovieAsync(MovieDto dto);
    
    Task DeleteMovieAsync(string id);

    Task<MovieDto> GetMovieByIdAsync(string id);

    Task<List<MovieDto>> GetAllMoviesAsync(MovieFilterModel filterModel);
}