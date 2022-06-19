using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using FilmBegetter.Domain;
using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.BLL.Services;

class UserService : IUserService {

    private readonly IMapper _mapper;

    private readonly UserManager<User> _userManager;

    private readonly IUnitOfWork _unitOfWork;

    public UserService(IMapper mapper, UserManager<User> userManager, IUnitOfWork unitOfWork) {
        _mapper = mapper;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegistrationResponseDto> CreateUserAccountAsync(UserDto userDto) {
        
        var user = _mapper.Map<User>(userDto);

        var subscription = await _unitOfWork.GetRepository<IRepository<Subscription>, Subscription>()
            .FirstOrDefaultAsync(s => s.Type == SubscriptionTypes.Basic);

        user.SubscriptionId = subscription.Id;
        
        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded) {

            await _userManager.AddToRoleAsync(user, UserRoles.User);
            
            return new RegistrationResponseDto() {
                IsSuccessfulRegistration = true
            };
        }
        
        var errors = result.Errors.Select(e => e.Description);

        return new RegistrationResponseDto { Errors = errors };
    }
}