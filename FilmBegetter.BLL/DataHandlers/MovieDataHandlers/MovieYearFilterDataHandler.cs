using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.DataHandlers.MovieDataHandlers;

public class MovieYearFilterDataHandler : DataHandler<Movie, MovieFilterModel> {
    public override void AddExpression(Expressions<Movie> expressions, MovieFilterModel filterModel) {
        
        if (filterModel.Year.HasValue && filterModel.Year.Value > 0) {
            expressions.FilterExpressions.Add(g => g.PublicationDate.Year == filterModel.Year.Value);
        }
        
        base.AddExpression(expressions, filterModel);
    }
}