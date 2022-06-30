using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.DAL.Repositories;

public class MovieCollectionRepository : Repository<MovieCollection>, IMovieCollectionRepository {
    
    public MovieCollectionRepository(ApplicationDbContext context) : base(context) {
    }

    protected override IQueryable<MovieCollection> FindAllWithDetailsWithoutFilter() {
        
        return Context.MovieCollections
            .Include(mc => mc.MovieCollections)
            .ThenInclude(mc => mc.Movie)
            .AsNoTracking();
    }
}