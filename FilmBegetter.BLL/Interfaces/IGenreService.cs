using FilmBegetter.BLL.Dto;

namespace FilmBegetter.BLL.Interfaces;

public interface IGenreService {

    Task<List<GenreDto>> GetAllGenresAsync();

}