using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.DAL.Repositories;

class MovieRepository : Repository<Movie>, IMovieRepository {
    
    public MovieRepository(ApplicationDbContext context) : base(context) {
    }

    protected override IQueryable<Movie> FindAllWithDetailsWithoutFilter() {
        return Context.Movies
            .Include(m => m.Comments)
            .Include(m => m.Ratings)
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .AsSplitQuery()
            .AsNoTracking();
    }
}