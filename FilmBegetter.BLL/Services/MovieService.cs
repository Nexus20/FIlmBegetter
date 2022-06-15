using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.BLL.Pipelines.Directors;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;

namespace FilmBegetter.BLL.Services;

class MovieService : IMovieService {

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

        await _unitOfWork.SaveChangesAsync();
    }

    public Task UpdateMovieAsync(MovieDto dto) {
        
        // ValidateMovie(dto);

        var movie = _mapper.Map<MovieDto, Movie>(dto);

        _unitOfWork.GetRepository<IRepository<Movie>, Movie>().Update(movie);

        return _unitOfWork.SaveChangesAsync();
    }

    public Task DeleteMovieAsync(string id) {
        throw new NotImplementedException();
    }

    public Task<MovieDto> GetMovieByIdAsync(string id) {
        throw new NotImplementedException();
    }

    public async Task<List<MovieDto>> GetAllMoviesAsync(MovieFilterModel filterModel) {
        
        var pipeline = new SelectionPipeline<Movie, MovieFilterModel>(filterModel, _builderDirector);

        var expressions = pipeline.Process();

        var source = await _unitOfWork.GetRepository<IMovieRepository, Movie>().FindAllWithDetailsAsync(expressions);

        return _mapper.Map<List<Movie>, List<MovieDto>>(source);
    }
}