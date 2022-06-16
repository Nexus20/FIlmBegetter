using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using FilmBegetter.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilmBegetter.DAL; 

public static class DalDependencyInjectionExtensions {
    
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString) {

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IMovieRepository, MovieRepository>();

        services.AddDbContext<ApplicationDbContext>(options => options
            // .UseLazyLoadingProxies()
            .UseSqlServer(connectionString));
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleManager<RoleManager<IdentityRole>>();

        return services;
    }
}