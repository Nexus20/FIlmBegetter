using System.Net;
using System.Security.Claims;
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
using Newtonsoft.Json.Linq;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase {

    private readonly IMovieService _movieService;

    private readonly IMapper _mapper;

    private readonly RequestResponseService _requestResponseService;
    
    private readonly IWebHostEnvironment _appEnvironment;

    private readonly IUserService _userService;
    
    // GET: api/Movies
    public MoviesController(IMovieService movieService, IMapper mapper, RequestResponseService requestResponseService, IWebHostEnvironment appEnvironment, IUserService userService) {
        _movieService = movieService;
        _mapper = mapper;
        _requestResponseService = requestResponseService;
        _appEnvironment = appEnvironment;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]MovieFilterViewModel filter) {

        filter.PageNumber ??= 1;
        filter.TakeCount ??= 10;

        var source = await _movieService.GetAllMoviesAsync(_mapper.Map<MovieFilterViewModel, MovieFilterModel>(filter)); 
        
        return Ok(_mapper.Map<List<MovieDto>, List<MovieViewModel>>(source));
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
    public async Task<IActionResult> Post([FromForm]MovieToCreateViewModel model) {

        if (!ModelState.IsValid) {
            return BadRequest();
        }
        
        var dto = _mapper.Map<MovieToCreateViewModel, MovieDto>(model);

        try {
            
            var files = Request.Form.Files;
            
            if (files.Count > 0) {

                var image = files[0];
                
                await UploadImage(image);
            
                var path = $"/img/movies/{image.FileName}";
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
    public async Task<IActionResult> Put(string id, [FromForm] MovieToUpdateViewModel model) {
        
        if (!ModelState.IsValid) {
            return BadRequest();
        }
        
        var dto = _mapper.Map<MovieToUpdateViewModel, MovieDto>(model);

        try {

            var files = Request.Form.Files;
            
            if (files.Count > 0) {

                var image = files[0];
                
                await UploadImage(image);
            
                var path = $"/img/movies/{image.FileName}";
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

    [HttpPost]
    [Authorize]
    [Route("recommend")]
    public async Task<IActionResult> Recommend(SelectedMoviesViewModel selectedMovies) {

        if (!ModelState.IsValid) {
            return BadRequest();
        }

        var response = await _requestResponseService.Invoke(selectedMovies.FirstMovieId, selectedMovies.SecondMovieId);

        var obj = JObject.Parse(response);

        var suggestedMoviesIds = obj["Results"]["output1"]["value"]["Values"][0]
            .Select(i => i.Value<string>()).Where(id => id != selectedMovies.FirstMovieId && id != selectedMovies.SecondMovieId);

        var model = new List<MovieViewModel>();
        
        foreach (var id in suggestedMoviesIds) {
            
            if (id == null || id == selectedMovies.FirstMovieId || id == selectedMovies.SecondMovieId) {
                continue;
            }
            
            var movie = await _movieService.GetMovieByIdAsync(id);
            model.Add(_mapper.Map<MovieDto, MovieViewModel>(movie));
        }

        model = model.OrderByDescending(m => m.CommonRating).ToList();
        
        var user = await _userService.GetUserByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

        if (user.Subscription.Type == SubscriptionTypes.Basic) {
            model = model.Take(5).ToList();
        }

        return Ok(model);
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