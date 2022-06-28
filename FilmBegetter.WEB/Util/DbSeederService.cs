using FilmBegetter.BLL;

namespace FilmBegetter.WEB.Util; 

public class DbSeederService : BackgroundService {

    private readonly IConfiguration _configuration;

    private readonly IServiceProvider _serviceProvider;

    public DbSeederService(IConfiguration configuration, IServiceProvider serviceProvider) {
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {

        if (_configuration["DataSeedingSettings:IsDataSeeded"] == "true") {
            return;
        }

        await DoWorkAsync(stoppingToken);
    }

    private async Task DoWorkAsync(CancellationToken stoppingToken) {
        
        using var scope = _serviceProvider.CreateScope();
        await scope.ServiceProvider.GetRequiredService<DbInitializingService>().Initialize();
    }
}