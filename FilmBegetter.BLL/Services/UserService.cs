using AutoMapper;
using FilmBegetter.BLL.Dto;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.BLL.Pipelines.Directors;
using FilmBegetter.BLL.Utils;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using FilmBegetter.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.BLL.Services;

public class UserService : IUserService {

    private readonly IMapper _mapper;

    private readonly UserManager<User> _userManager;

    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IPipelineBuilderDirector<User, UserFilterModel> _builderDirector;

    private readonly ApplicationDbContext _applicationDbContext;

    public UserService(IMapper mapper, UserManager<User> userManager, IUnitOfWork unitOfWork, IPipelineBuilderDirector<User, UserFilterModel> builderDirector, ApplicationDbContext applicationDbContext) {
        _mapper = mapper;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _builderDirector = builderDirector;
        _applicationDbContext = applicationDbContext;
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

    public async Task<List<UserDto>> GetAllUsersAsync(UserFilterModel filterModel) {
        
        var pipeline = new SelectionPipeline<User, UserFilterModel>(filterModel, _builderDirector);

        var expressions = pipeline.Process();

        var source = await _userManager.FindAllWithDetailsAsync(expressions);

        return _mapper.Map<List<User>, List<UserDto>>(source);
    }

    public async Task<UserDto> GetUserByIdAsync(string id) {

        var source = await _userManager.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Include(u => u.Subscription)
            .Include(m => m.MovieCollections)
            .ThenInclude(mc => mc.MovieCollections)
            .ThenInclude(mmc => mmc.Movie)
            .Include(u => u.SentFriendRequests)
            .Include(u => u.RecievedFriendRequests)
            // .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

        foreach (var request in source.SentFriendRequests) {
            await _applicationDbContext.Entry(request).Reference(x => x.Recipient).LoadAsync();
        }
        
        foreach (var request in source.RecievedFriendRequests) {
            await _applicationDbContext.Entry(request).Reference(x => x.Sender).LoadAsync();
        }

        return _mapper.Map<User, UserDto>(source);
    }

    public async Task UpdateSubscription(string userId, string type) {

        var user = await _userManager.FindByIdAsync(userId);

        var subscription = await _unitOfWork.GetRepository<IRepository<Subscription>, Subscription>()
            .FirstOrDefaultAsync(s => s.Type == type);

        user.SubscriptionId = subscription.Id;
        
        if (type == SubscriptionTypes.Premium) {
            user.SubscriptionExpirationDare = user.SubscriptionExpirationDare?.AddMonths(1) ?? DateTime.Now.AddMonths(1);
        }
        else {
            user.SubscriptionExpirationDare = null;
        }

        await _userManager.UpdateAsync(user);
    }

    public async Task CheckSubscriptionExpiration(string userId) {

        var user = await _userManager.FindByIdAsync(userId);

        var currentSubscription = await _unitOfWork.GetRepository<IRepository<Subscription>, Subscription>()
            .FirstOrDefaultAsync(s => s.Id == user.SubscriptionId);

        if (currentSubscription.Type == SubscriptionTypes.Premium && DateTime.Now >= user.SubscriptionExpirationDare) {

            var basicSubscription = await _unitOfWork.GetRepository<IRepository<Subscription>, Subscription>()
                .FirstOrDefaultAsync(s => s.Type == SubscriptionTypes.Basic);

            user.SubscriptionId = basicSubscription.Id;
            user.SubscriptionExpirationDare = null;

            await _userManager.UpdateAsync(user);
        }
    }

    public async Task UpdateUserAsync(UserDto dto) {
        
        var user = await _userManager.FindByIdAsync(dto.Id);

        user.Name = dto.Name;
        user.Surname = dto.Surname;
        user.Email = dto.Email;
        user.UserName = dto.UserName;

        await _userManager.UpdateAsync(user);
    }
}