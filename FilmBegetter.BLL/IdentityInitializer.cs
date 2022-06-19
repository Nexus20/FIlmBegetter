using FilmBegetter.DAL.Entities;
using FilmBegetter.Domain;
using Microsoft.AspNetCore.Identity;

namespace FilmBegetter.BLL; 

public class IdentityInitializer {
    
    private readonly UserManager<User> _userManager;

    private readonly RoleManager<Role> _roleManager;

    public IdentityInitializer(UserManager<User> userManager, RoleManager<Role> roleManager) {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void Initialize() {
        
        var superAdmin = _userManager.Users.FirstOrDefault(u => u.UserName == "root") ?? RegisterSuperAdmin();
        var superAdminRole = RegisterAdminRole();

        if (_userManager.Users.FirstOrDefault(u =>
                u.Id == superAdmin.Id && u.UserRoles.Select(ur => ur.Role.Name).Contains(superAdminRole.Name)) == null) {
            _userManager.AddToRoleAsync(superAdmin, superAdminRole.Name).Wait();
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

        var superAdmin = new User() {
            UserName = "root",
        };

        _userManager.CreateAsync(superAdmin, "_ABCabc123_").Wait();

        return superAdmin;
    }
}