using System.Linq.Expressions;
using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.DAL.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository {
    
    public MovieRepository(ApplicationDbContext context) : base(context) {
    }

    public override Task<List<Movie>> FindAsync(Expression<Func<Movie, bool>> filter) {
        return Context.Movies
            .Include(m => m.Ratings)
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Where(filter)
            .AsSingleQuery()
            .AsNoTracking()
            .ToListAsync();
    }

    public override Task<List<Movie>> FindAllWithDetailsAsync(Expressions<Movie> expressions) {

        var query = Context.Movies
            .Include(m => m.Ratings)
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .AsQueryable();

        query = ApplyFilters(query, expressions);
        
        return query.AsSplitQuery().AsNoTracking().ToListAsync();
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