using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.DAL.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository {
    
    public MovieRepository(ApplicationDbContext context) : base(context) {
    }

    protected override IQueryable<Movie> FindAllWithDetailsWithoutFilter() {
        return Context.Movies
            .Include(m => m.Comments)
            .ThenInclude(c => c.Author)
            .Include(m => m.Comments)
            .ThenInclude(c => c.CommentRatings)
            .Include(m => m.Ratings)
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .AsSplitQuery()
            .AsNoTracking();
    }
}