using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.DataHandlers.MovieDataHandlers;

public class MovieGenresFilterDataHandler : DataHandler<Movie, MovieFilterModel> {

    public override void AddExpression(Expressions<Movie> expressions, MovieFilterModel filterModel) {

        if (filterModel.Genres?.Any() == true) {
            expressions.FilterExpressions.Add(g => g.MovieGenres.Any(mg => filterModel.Genres.Contains(mg.Genre.Name)));
        }

        base.AddExpression(expressions, filterModel);
    }
}