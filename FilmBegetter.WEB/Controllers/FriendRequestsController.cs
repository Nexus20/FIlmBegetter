using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendRequestsController : ControllerBase {

        private readonly IFriendRequestService _friendRequestService;
        
        // GET: api/FriendRequests
        public FriendRequestsController(IFriendRequestService friendRequestService) {
            _friendRequestService = friendRequestService;
        }

        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // // GET: api/FriendRequests/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST: api/FriendRequests
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FriendRequestToCreateViewModel viewModel) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            try {
                await _friendRequestService.CreateRequestAsync(viewModel.SenderId, viewModel.RecipientId);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
            
            return Ok();
        }

        // PUT: api/FriendRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] FriendRequestToUpdateViewModel viewModel) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            try {
                await _friendRequestService.UpdateRequestAsync(id, viewModel.Status);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }

            return Ok();
        }

        // DELETE: api/FriendRequests/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
