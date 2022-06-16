using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.FilterModels;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase {

    private readonly IMovieService _movieService;

    private readonly IMapper _mapper;
    
    // GET: api/Movies
    public MoviesController(IMovieService movieService, IMapper mapper) {
        _movieService = movieService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<List<MovieViewModel>> Get([FromQuery]MovieFilterViewModel filter) {

        filter.PageNumber ??= 1;
        filter.TakeCount ??= 10;

        var source = await _movieService.GetAllMoviesAsync(_mapper.Map<MovieFilterViewModel, MovieFilterModel>(filter)); 
        
        return _mapper.Map<List<MovieDto>, List<MovieViewModel>>(source);
    }

    // GET: api/Movies/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<MovieViewModel> Get(string id) {

        var source = await _movieService.GetMovieByIdAsync(id); 
        
        return _mapper.Map<MovieDto, MovieViewModel>(source);
    }

    // POST: api/Movies
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Movies/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Movies/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}