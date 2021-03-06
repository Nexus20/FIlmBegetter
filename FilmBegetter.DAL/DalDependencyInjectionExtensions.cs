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
        services.AddScoped<IMovieCollectionRepository, MovieCollectionRepository>();

        services.AddDbContext<ApplicationDbContext>(options => options
            // .UseLazyLoadingProxies()
            .UseSqlServer(connectionString));
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleManager<RoleManager<Role>>();

        services.AddScoped<DbInitializer>();
        
        return services;
    }
}