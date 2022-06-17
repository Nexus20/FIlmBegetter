using FilmBegetter.BLL.Dto;

namespace FilmBegetter.BLL.Interfaces;

public interface IUserService {

    Task<RegistrationResponseDto> CreateUserAccountAsync(UserDto userDto);
}