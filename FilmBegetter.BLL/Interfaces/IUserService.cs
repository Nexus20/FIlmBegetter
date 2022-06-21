using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;

namespace FilmBegetter.BLL.Interfaces;

public interface IUserService {

    Task<RegistrationResponseDto> CreateUserAccountAsync(UserDto userDto);
    
    Task<List<UserDto>> GetAllUsersAsync(UserFilterModel filterModel);
    
    Task<UserDto> GetUserByIdAsync(string id);
    
    Task UpdateSubscription(string userId, string type);

    Task CheckSubscriptionExpiration(string userId);
}