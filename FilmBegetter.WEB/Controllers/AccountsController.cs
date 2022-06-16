using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FilmBegetter.WEB.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase {

    private readonly IMapper _mapper;

    private readonly IUserService _userService;

    public AccountsController(IMapper mapper, IUserService userService) {
        _mapper = mapper;
        _userService = userService;
    }
    
    [HttpPost("Registration")] 
    public async Task<IActionResult> RegisterUser([FromBody] RegistrationViewModel userForRegistration) {
        
        if (userForRegistration == null || !ModelState.IsValid) 
            return BadRequest(); 
            
        var dto = _mapper.Map<RegistrationViewModel, UserDto>(userForRegistration);
        
        var result = await _userService.CreateUserAccountAsync(dto);

        return result.IsSuccessfulRegistration ? StatusCode(201) : BadRequest(result);
    }
}