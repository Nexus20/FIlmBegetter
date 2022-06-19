using FilmBegetter.BLL.DataHandlers;
using FilmBegetter.BLL.DataHandlers.MovieDataHandlers;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Interfaces;
using FilmBegetter.BLL.Pipelines.Builders;
using FilmBegetter.BLL.Pipelines.Directors;
using FilmBegetter.BLL.Services;
using FilmBegetter.BLL.Utils;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace FilmBegetter.BLL; 

public static class BllDependencyInjectionExtensions {
    
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, string connectionString) {
        
        services.AddDataAccessLayer(connectionString);
        
        services.AddAutoMapper(typeof(AutomapperBllProfile));

        services.AddScoped<JwtHandler>();
        
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<ISignInService, SignInService>();
        
        services.AddScoped<IMovieService, MovieService>();
        
        services.AddScoped(typeof(IPipelineBuilder<,>), typeof(SelectionPipelineBuilder<,>));

        services.AddScoped<IPipelineBuilderDirector<Movie, MovieFilterModel>, MovieSelectionPipelineBuilderDirector>();

        services.AddScoped<MovieTitleFilterDataHandler>();

        services.AddScoped(typeof(SkipObjectsDataHandler<,>));
        services.AddScoped(typeof(TakeObjectsDataHandler<,>));
        
        return services;
    }
}