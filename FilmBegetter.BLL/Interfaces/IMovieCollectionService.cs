using FilmBegetter.BLL.Dto;

namespace FilmBegetter.BLL.Interfaces;

public interface IMovieCollectionService {
    
    Task CreateCollectionAsync(MovieCollectionDto dto);
}