using FilmBegetter.DAL;

namespace FilmBegetter.BLL;

public class DbInitializingService {

    private readonly DbInitializer _dbInitializer;


    public DbInitializingService(DbInitializer dbInitializer) {
        _dbInitializer = dbInitializer;
    }

    public Task Initialize() {
        return _dbInitializer.Initialize();
    }
}