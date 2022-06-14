using FilmBegetter.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilmBegetter.DAL; 

public static class DalDependencyInjectionExtensions {
    
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString) {

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleManager<RoleManager<IdentityRole>>();

        return services;
    }
}