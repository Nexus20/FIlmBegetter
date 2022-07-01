using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using FilmBegetter.Domain;
using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.BLL;

public class IdentityInitializer {
    
    private readonly UserManager<User> _userManager;

    private readonly RoleManager<Role> _roleManager;

    private readonly IUnitOfWork _unitOfWork;

    public IdentityInitializer(UserManager<User> userManager, RoleManager<Role> roleManager, IUnitOfWork unitOfWork) {
        _userManager = userManager;
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
    }

    public void Initialize() {
        
        var admin = _userManager.Users.FirstOrDefault(u => u.UserName == "root") ?? RegisterSuperAdmin();
        var adminRole = RegisterAdminRole();

        if (_userManager.Users.FirstOrDefault(u =>
                u.Id == admin.Id && u.UserRoles.Select(ur => ur.Role.Name).Contains(adminRole.Name)) == null) {
            _userManager.AddToRoleAsync(admin, adminRole.Name).Wait();
        }
    }

    private Role RegisterAdminRole() {

        var role = _roleManager.Roles.FirstOrDefault(r => r.Name == UserRoles.Admin);

        if (role != null) {
            return role;
        }

        role = new Role(UserRoles.Admin);
        _roleManager.CreateAsync(role).Wait();
        
        return role;
    }

    private User RegisterSuperAdmin() {

        var subscription = _unitOfWork.GetRepository<IRepository<Subscription>, Subscription>()
            .FirstOrDefault(s => s.Type == SubscriptionTypes.Basic);
        
        var superAdmin = new User() {
            Name = "root",
            Surname = "root",
            UserName = "admin@filmbegetter.com",
            Email = "admin@filmbegetter.com",
            SubscriptionId = subscription.Id
        };

        _userManager.CreateAsync(superAdmin, "_ABCabc123_").Wait();

        return superAdmin;
    }
}