using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;
using FilmBegetter.Domain;

namespace FilmBegetter.BLL.DataHandlers.MovieDataHandlers;

public class MovieOrderDataHandler : DataHandler<Movie, MovieFilterModel> {
    public override void AddExpression(Expressions<Movie> expressions, MovieFilterModel filterModel) {
        
        if (filterModel.OrderTypes?.Any() == true) {

            foreach (var orderType in filterModel.OrderTypes) {

                switch (orderType) {
                    case MovieOrderType.RatingAsc:
                        expressions.AscendingOrderExpressions.Add(m => m.Ratings.Average(r => r.RatingValue));
                        break;
                    case MovieOrderType.RatingDesc:
                        expressions.DescendingOrderExpressions.Add(m => m.Ratings.Average(r => r.RatingValue));
                        break;
                }
            }
        }
        
        base.AddExpression(expressions, filterModel);
    }
}