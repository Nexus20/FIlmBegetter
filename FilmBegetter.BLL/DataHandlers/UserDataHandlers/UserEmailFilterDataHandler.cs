using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.DataHandlers.UserDataHandlers;

public class UserEmailFilterDataHandler : DataHandler<User, UserFilterModel> {

    public override void AddExpression(Expressions<User> expressions, UserFilterModel filterModel) {

        if (!string.IsNullOrWhiteSpace(filterModel.Email)) {
            expressions.FilterExpressions.Add(g => g.Email.Contains(filterModel.Email));
        }

        base.AddExpression(expressions, filterModel);
    }
}