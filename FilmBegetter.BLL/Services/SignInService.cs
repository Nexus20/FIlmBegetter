using System.IdentityModel.Tokens.Jwt;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.BLL.Utils;
using FilmBegetter.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.BLL.Services;

public class SignInService : ISignInService {

    private readonly UserManager<User> _userManager;

    private readonly JwtHandler _jwtHandler;

    public SignInService(UserManager<User> userManager, JwtHandler jwtHandler) {
        _userManager = userManager;
        _jwtHandler = jwtHandler;
    }

    public async Task<AuthenticationResponseDto> SignInAsync(AuthenticationDto dto) {
        
        
        var user = await _userManager.FindByNameAsync(dto.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password)) {
            return new AuthenticationResponseDto() {
                ErrorMessage = "Invalid Authentication"
            };
        }

        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var claims = await _jwtHandler.GetClaimsAsync(user);
        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        
        return new AuthenticationResponseDto() { IsAuthSuccessful = true, Token = token };
    }
}