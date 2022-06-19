
using FilmBegetter.BLL;
using FilmBegetter.WEB.Util;

namespace FilmBegetter.WEB; 

public static class WebDependencyInjectionExtensions {
    
    public static IServiceCollection AddWebLayer(this IServiceCollection services, string connectionString) {
        
        services.AddBusinessLogicLayer(connectionString);
        
        services.AddAutoMapper(typeof(AutomapperWebProfile));

        services.AddScoped<RequestResponseService>();
        
        return services;
    }
}