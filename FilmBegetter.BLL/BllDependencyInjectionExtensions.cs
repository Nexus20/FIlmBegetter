using FilmBegetter.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace FilmBegetter.BLL; 

public static class BllDependencyInjectionExtensions {
    
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, string connectionString) {
        
        services.AddDataAccessLayer(connectionString);

        return services;
    }
}