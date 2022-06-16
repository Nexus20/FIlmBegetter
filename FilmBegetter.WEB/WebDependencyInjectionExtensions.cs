
using FilmBegetter.BLL;

namespace FilmBegetter.WEB; 

public static class WebDependencyInjectionExtensions {
    
    public static IServiceCollection AddWebLayer(this IServiceCollection services, string connectionString) {
        
        services.AddBusinessLogicLayer(connectionString);
        
        services.AddAutoMapper(typeof(AutomapperWebProfile));
        
        return services;
    }
}