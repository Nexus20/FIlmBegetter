using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase {

        private readonly IMapper _mapper;
        
        private readonly ICommentService _commentService;

        // GET: api/Comments
        public CommentsController(IMapper mapper, ICommentService commentService) {
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // // GET: api/Comments/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST: api/Comments
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CommentToCreateViewModel viewModel) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var dto = _mapper.Map<CommentToCreateViewModel, CommentDto>(viewModel);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            dto.AuthorId = userId;
            
            var resultDto = await _commentService.CreateCommentAsync(dto);

            return Ok(_mapper.Map<CommentDto, CommentViewModel>(resultDto));
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateCommentRatingViewModel viewModel) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            await _commentService.UpdateRatingAsync(userId, viewModel.CommentId, viewModel.Rating);

            return Ok();
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
