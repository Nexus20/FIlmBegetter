using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.FilterModels;
using FilmBegetter.WEB.Models.ViewModels;
using FilmBegetter.WEB.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase {

    private readonly IMovieService _movieService;

    private readonly IMapper _mapper;

    private readonly RequestResponseService _requestResponseService;
    
    // GET: api/Movies
    public MoviesController(IMovieService movieService, IMapper mapper, RequestResponseService requestResponseService) {
        _movieService = movieService;
        _mapper = mapper;
        _requestResponseService = requestResponseService;
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

    [HttpGet]
    [Route("recommend")]
    public async Task<List<MovieViewModel>> Get() {

        var response = await _requestResponseService.Invoke();

        var obj = JObject.Parse(response);

        var suggestedMoviesIds = obj["Results"]["output1"]["value"]["Values"][0]
            .Select(i => i.Value<string>());

        var model = new List<MovieViewModel>();
        
        foreach (var id in suggestedMoviesIds) {
            
            if (id == null) {
                continue;
            }
            
            var movie = await _movieService.GetMovieByIdAsync(id);
            model.Add(_mapper.Map<MovieDto, MovieViewModel>(movie));
        }

        return model;
    }
}