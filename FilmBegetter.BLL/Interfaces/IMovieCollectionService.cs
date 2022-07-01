using FilmBegetter.BLL.Dto;

namespace FilmBegetter.BLL.Interfaces;

public interface IMovieCollectionService {
    
    Task CreateCollectionAsync(MovieCollectionDto dto);
    
    Task<List<MovieCollectionDto>> GetUserCollectionsAsync(string userId);
    
    Task AddMovieAsync(string collectionId, string movieId);

    Task RemoveMovieAsync(string collectionId, string movieId);
    
    Task<MovieCollectionDto> GetCollectionByIdAsync(string id);
}