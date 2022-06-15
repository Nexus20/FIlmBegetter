using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.DataHandlers;

public class MovieTitleFilterDataHandler : DataHandler<Movie, MovieFilterModel> {

    public override void AddExpression(Expressions<Movie> expressions, MovieFilterModel filterModel) {

        if (!string.IsNullOrWhiteSpace(filterModel.Title)) {
            expressions.FilterExpressions.Add(g => g.Title.Contains(filterModel.Title));
        }

        base.AddExpression(expressions, filterModel);
    }
}