using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.BLL.Pipelines.Directors;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;

namespace FilmBegetter.BLL.Services;

public class MovieService : IMovieService {

    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;
    
    private readonly IPipelineBuilderDirector<Movie, MovieFilterModel> _builderDirector;

    public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IPipelineBuilderDirector<Movie, MovieFilterModel> builderDirector) {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _builderDirector = builderDirector;
    }

    public async Task CreateMovieAsync(MovieDto dto) {

        // ValidateMovie(dto);

        var movie = _mapper.Map<MovieDto, Movie>(dto);

        await _unitOfWork.GetRepository<IRepository<Movie>, Movie>().CreateAsync(movie);


        foreach (var genreDto in dto.Genres) {

            var movieGenre = new MovieGenre() {
                GenreId = genreDto.Id,
                MovieId = movie.Id
            };

            await _unitOfWork.GetRepository<IRepository<MovieGenre>, MovieGenre>().CreateAsync(movieGenre);
        }
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateMovieAsync(MovieDto dto) {
        
        // ValidateMovie(dto);

        var movie = _mapper.Map<MovieDto, Movie>(dto);

        _unitOfWork.GetRepository<IRepository<Movie>, Movie>().Update(movie);
        
        await _unitOfWork.GetRepository<IRepository<MovieGenre>, MovieGenre>().DeleteAsync(mg => mg.MovieId == movie.Id);
        
        foreach (var genreDto in dto.Genres) {

            var movieGenre = new MovieGenre() {
                GenreId = genreDto.Id,
                MovieId = movie.Id
            };

            await _unitOfWork.GetRepository<IRepository<MovieGenre>, MovieGenre>().CreateAsync(movieGenre);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public Task DeleteMovieAsync(string id) {
        throw new NotImplementedException();
    }

    public async Task<MovieDto> GetMovieByIdAsync(string id) {

        var source = await _unitOfWork.GetRepository<IMovieRepository, Movie>()
            .FirstOrDefaultWithDetailsAsync(x => x.Id == id);

        return _mapper.Map<Movie, MovieDto>(source);
    }

    public async Task<List<MovieDto>> GetAllMoviesAsync(MovieFilterModel filterModel) {
        
        var pipeline = new SelectionPipeline<Movie, MovieFilterModel>(filterModel, _builderDirector);

        var expressions = pipeline.Process();

        var source = await _unitOfWork.GetRepository<IMovieRepository, Movie>().FindAllWithDetailsAsync(expressions);

        return _mapper.Map<List<Movie>, List<MovieDto>>(source);
    }
}