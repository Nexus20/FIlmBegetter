using System.Net;
using System.Security.Claims;
using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class CollectionsController : ControllerBase {
        
    private readonly IMapper _mapper;

    private readonly IMovieCollectionService _movieCollectionService;

    // GET: api/Collections
    public CollectionsController(IMapper mapper, IMovieCollectionService movieCollectionService) {
        _mapper = mapper;
        _movieCollectionService = movieCollectionService;
    }

    [HttpGet]
    [Authorize]
    [Route("currentUser")]
    public async Task<IActionResult> Get() {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var source = await _movieCollectionService.GetUserCollectionsAsync(userId);
            
        return Ok(_mapper.Map<List<MovieCollectionDto>, List<MovieCollectionViewModel>>(source));
    }

    [HttpGet]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> Get(string id) {
        
        var source = await _movieCollectionService.GetCollectionByIdAsync(id);
        
        return Ok(_mapper.Map<MovieCollectionDto, MovieCollectionViewModel>(source));
    }

    [HttpPost]
    [Authorize]
    [Route("{id}/add-movie")]
    public async Task<IActionResult> AddMovie(string id, MovieMovieCollectionViewModel viewModel) {

        if (!ModelState.IsValid) {
            return BadRequest();
        }

        try {
            await _movieCollectionService.AddMovieAsync(viewModel.CollectionId, viewModel.MovieId);
        }
        catch (Exception ex) {
            return BadRequest(ex);
        }
        
        return Ok();
    }
    
    [HttpPost]
    [Authorize]
    [Route("{id}/remove-movie")]
    public async Task<IActionResult> RemoveMovie(string id, MovieMovieCollectionViewModel viewModel) {

        if (!ModelState.IsValid) {
            return BadRequest();
        }

        try {
            await _movieCollectionService.RemoveMovieAsync(viewModel.CollectionId, viewModel.MovieId);
        }
        catch (Exception ex) {
            return BadRequest(ex);
        }
        
        return Ok();
    }

    // [HttpGet]
    // public IEnumerable<string> Get()
    // {
    //     return new string[] { "value1", "value2" };
    // }
    //
    // // GET: api/Collections/5
    // [HttpGet("{id}", Name = "Get")]
    // public string Get(int id)
    // {
    //     return "value";
    // }

    // POST: api/Collections
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MovieCollectionToCreateViewModel viewModel) {

        if (!ModelState.IsValid) {
            return BadRequest();
        }

        try {
            var dto = _mapper.Map<MovieCollectionToCreateViewModel, MovieCollectionDto>(viewModel);
            await _movieCollectionService.CreateCollectionAsync(dto);
        }
        catch (Exception ex) {
            return BadRequest();
        }

        return StatusCode((int)HttpStatusCode.Created);
    }

    // PUT: api/Collections/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE: api/Collections/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}