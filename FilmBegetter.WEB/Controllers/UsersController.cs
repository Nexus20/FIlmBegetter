using System.Security.Claims;
using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.Domain;
using FilmBegetter.WEB.Models.FilterModels;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IEnumerable<UserViewModel>> Get([FromQuery]UserFilterViewModel filter) {
            
            filter.PageNumber ??= 1;
            filter.TakeCount ??= 10;

            var source = await _userService.GetAllUsersAsync(_mapper.Map<UserFilterViewModel, UserFilterModel>(filter));

            return _mapper.Map<List<UserDto>, List<UserViewModel>>(source);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<UserViewModel> Get(string id) {
            
            var source = await _userService.GetUserByIdAsync(id);

            return _mapper.Map<UserDto, UserViewModel>(source);
        }

        [HttpGet]
        [Route("currentUser")]
        [Authorize]
        public async Task<UserViewModel> GetCurrentUser() {

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var source = await _userService.GetUserByIdAsync(currentUserId);
            
            return _mapper.Map<UserDto, UserViewModel>(source);
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // // PUT: api/Users/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/Users/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }

        [HttpPut]
        [Authorize]
        [Route("updateSubscription")]
        public async Task<IActionResult> UpdateSubscription([FromBody]SubscriptionChangeResponseViewModel responce) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            try {
                await _userService.UpdateSubscription(responce.UserId, responce.Type);
            }
            catch (Exception ex) {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id}/update-roles")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateUserRoles(string id, UpdateUserRolesViewModel viewModel) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            try {
                await _userService.UpdateUserRolesAsync(viewModel.UserId, viewModel.Roles);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }

            return Ok();
        }
        
        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAccount(UserToUpdateViewModel viewModel) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            try {
                var dto = _mapper.Map<UserToUpdateViewModel, UserDto>(viewModel);
                await _userService.UpdateUserAsync(dto);
            }
            catch (Exception ex) {
                return BadRequest();
            }
            
            return Ok();
        }
    }
}
