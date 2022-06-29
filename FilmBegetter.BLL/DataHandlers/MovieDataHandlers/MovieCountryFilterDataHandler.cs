using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.DataHandlers.MovieDataHandlers;

public class MovieCountryFilterDataHandler : DataHandler<Movie, MovieFilterModel> {

    public override void AddExpression(Expressions<Movie> expressions, MovieFilterModel filterModel) {

        if (!string.IsNullOrWhiteSpace(filterModel.Country)) {
            expressions.FilterExpressions.Add(m => m.Country.Contains(filterModel.Country));
        }

        base.AddExpression(expressions, filterModel);
    }
}