using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase {

        private readonly IMapper _mapper;

        private readonly IGenreService _genreService;
        
        // GET: api/Genres
        public GenresController(IMapper mapper, IGenreService genreService) {
            _mapper = mapper;
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {

            var source = await _genreService.GetAllGenresAsync();

            return Ok(_mapper.Map<List<GenreDto>, List<GenreViewModel>>(source));
        }

        // // GET: api/Genres/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }
        //
        // // POST: api/Genres
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }
        //
        // // PUT: api/Genres/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/Genres/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
