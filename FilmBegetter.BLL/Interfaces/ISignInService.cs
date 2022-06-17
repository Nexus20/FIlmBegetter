using FilmBegetter.BLL.Dto;

namespace FilmBegetter.BLL.Interfaces; 

public interface ISignInService {

    Task<AuthenticationResponseDto> SignInAsync(AuthenticationDto dto);
}