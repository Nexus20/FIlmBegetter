using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.DataHandlers.MovieDataHandlers;

public class MovieDirectorFilterDataHandler : DataHandler<Movie, MovieFilterModel> {

    public override void AddExpression(Expressions<Movie> expressions, MovieFilterModel filterModel) {

        if (!string.IsNullOrWhiteSpace(filterModel.Director)) {
            expressions.FilterExpressions.Add(m => m.Director.Contains(filterModel.Director));
        }

        base.AddExpression(expressions, filterModel);
    }
}