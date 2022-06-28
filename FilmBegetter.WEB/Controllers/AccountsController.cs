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

    private readonly ISignInService _signInService;

    public AccountsController(IMapper mapper, IUserService userService, ISignInService signInService) {
        _mapper = mapper;
        _userService = userService;
        _signInService = signInService;
    }
    
    [HttpPost("Registration")] 
    public async Task<IActionResult> RegisterUser([FromBody] RegistrationViewModel userForRegistration) {
        
        if (userForRegistration == null || !ModelState.IsValid) 
            return BadRequest(); 
            
        var dto = _mapper.Map<RegistrationViewModel, UserDto>(userForRegistration);
        
        var result = await _userService.CreateUserAccountAsync(dto);

        return result.IsSuccessfulRegistration ? StatusCode(201) : BadRequest(result);
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] AuthenticationViewModel userForAuthentication) {

        if (!ModelState.IsValid) {
            return BadRequest();
        }

        var authenticationDto = _mapper.Map<AuthenticationViewModel, AuthenticationDto>(userForAuthentication);
        
        var responseDto = await _signInService.SignInAsync(authenticationDto);

        var responseViewModel = _mapper.Map<AuthenticationResponseDto, AuthenticationResponseViewModel>(responseDto);

        return responseViewModel.IsAuthSuccessful ? Ok(responseViewModel) : Unauthorized(responseViewModel);
    }
}