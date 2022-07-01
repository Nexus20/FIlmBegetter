using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;

namespace FilmBegetter.BLL.Services;

public class MovieCollectionService : IMovieCollectionService {

    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public MovieCollectionService(IMapper mapper, IUnitOfWork unitOfWork) {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateCollectionAsync(MovieCollectionDto dto) {

        var collection = _mapper.Map<MovieCollectionDto, MovieCollection>(dto);

        await _unitOfWork.GetRepository<IRepository<MovieCollection>, MovieCollection>().CreateAsync(collection);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<MovieCollectionDto>> GetUserCollectionsAsync(string userId) {

        var source = await _unitOfWork.GetRepository<IMovieCollectionRepository, MovieCollection>()
            .FindAsync(mc => mc.AuthorId == userId);

        return _mapper.Map<List<MovieCollection>, List<MovieCollectionDto>>(source);
    }

    public async Task RemoveMovieAsync(string collectionId, string movieId) {
        
        var movieMovieCollection = await _unitOfWork.GetRepository<IRepository<MovieMovieCollection>, MovieMovieCollection>()
            .FirstOrDefaultAsync(x => x.MovieCollectionId == collectionId && x.MovieId == movieId);

        if (movieMovieCollection == null) {
            return;
        }

        await _unitOfWork.GetRepository<IRepository<MovieMovieCollection>, MovieMovieCollection>()
            .DeleteAsync(x => x.MovieCollectionId == collectionId && x.MovieId == movieId);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<MovieCollectionDto> GetCollectionByIdAsync(string id) {

        var source = await _unitOfWork.GetRepository<IMovieCollectionRepository, MovieCollection>()
            .FirstOrDefaultWithDetailsAsync(mc => mc.Id == id);

        return _mapper.Map<MovieCollection, MovieCollectionDto>(source);
    }

    public async Task AddMovieAsync(string collectionId, string movieId) {

        var movieMovieCollection = await _unitOfWork.GetRepository<IRepository<MovieMovieCollection>, MovieMovieCollection>()
            .FirstOrDefaultAsync(x => x.MovieCollectionId == collectionId && x.MovieId == movieId);

        if (movieMovieCollection != null) {
            return;
        }

        movieMovieCollection = new MovieMovieCollection() {
            MovieId = movieId,
            MovieCollectionId = collectionId
        };

        await _unitOfWork.GetRepository<IRepository<MovieMovieCollection>, MovieMovieCollection>()
            .CreateAsync(movieMovieCollection);

        await _unitOfWork.SaveChangesAsync();
    }
}