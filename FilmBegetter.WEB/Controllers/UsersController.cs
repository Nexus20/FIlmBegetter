using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.FilterModels;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {

        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        // GET: api/Users
        public UsersController(IUserService userService, IMapper mapper) {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> Get([FromQuery]UserFilterViewModel filter) {
            
            filter.PageNumber ??= 1;
            filter.TakeCount ??= 10;

            var source = await _userService.GetAllUsersAsync(_mapper.Map<UserFilterViewModel, UserFilterModel>(filter));

            return _mapper.Map<List<UserDto>, List<UserViewModel>>(source);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<UserViewModel> Get(string id) {
            
            var source = await _userService.GetUserByIdAsync(id);

            return _mapper.Map<UserDto, UserViewModel>(source);
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
