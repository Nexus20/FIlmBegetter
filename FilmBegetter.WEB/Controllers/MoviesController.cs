using System.Net;
using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.Domain;
using FilmBegetter.WEB.Models.FilterModels;
using FilmBegetter.WEB.Models.ViewModels;
using FilmBegetter.WEB.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase {

    private readonly IMovieService _movieService;

    private readonly IMapper _mapper;

    private readonly RequestResponseService _requestResponseService;
    
    private readonly IWebHostEnvironment _appEnvironment;
    
    // GET: api/Movies
    public MoviesController(IMovieService movieService, IMapper mapper, RequestResponseService requestResponseService, IWebHostEnvironment appEnvironment) {
        _movieService = movieService;
        _mapper = mapper;
        _requestResponseService = requestResponseService;
        _appEnvironment = appEnvironment;
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
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> Post([FromBody] MovieToCreateViewModel model) {
        
        if (!ModelState.IsValid) {
            return BadRequest();
        }
        
        var dto = _mapper.Map<MovieToCreateViewModel, MovieDto>(model);

        try {

            if (model.ImageFile != null) {

                await UploadImage(model.ImageFile);

                var path = $"/img/movies/{model.ImageFile.FileName}";
                dto.ImagePath = path;
            }

            await _movieService.CreateMovieAsync(dto);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }

        return StatusCode((int)HttpStatusCode.Created);
    }

    // PUT: api/Movies/5
    [HttpPut("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> Put(string id, [FromBody] MovieToUpdateViewModel model) {
        
        if (!ModelState.IsValid) {
            return BadRequest();
        }
        
        var dto = _mapper.Map<MovieToUpdateViewModel, MovieDto>(model);

        try {

            if (model.ImageFile != null) {

                await UploadImage(model.ImageFile);

                var path = $"/img/movies/{model.ImageFile.FileName}";
                dto.ImagePath = path;
            }

            await _movieService.UpdateMovieAsync(dto);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }

        return NoContent();
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
    
    private async Task UploadImage(IFormFile file) {
        
        var directoryPath = Path.Combine(_appEnvironment.WebRootPath, "img", "movies");

        if (!Directory.Exists(directoryPath)) {
            var dirInfo = new DirectoryInfo(directoryPath);
            dirInfo.Create();
        }

        await using var fileStream = new FileStream(Path.Combine(directoryPath, file.FileName),
            FileMode.Create);
        await file.CopyToAsync(fileStream);
    }
}