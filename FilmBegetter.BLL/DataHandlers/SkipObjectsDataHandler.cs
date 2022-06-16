using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;

namespace FilmBegetter.BLL.DataHandlers;

public class SkipObjectsDataHandler<TEntity, TFilterModel> : DataHandler<TEntity, TFilterModel> where TEntity : class where TFilterModel : BaseFilterModel {

    public override void AddExpression(Expressions<TEntity> expressions, TFilterModel filterModel) {

        if (filterModel.PageNumber > 1) {
            expressions.SkipCount = filterModel.TakeCount * (filterModel.PageNumber - 1);
        }

        base.AddExpression(expressions, filterModel);
    }
}