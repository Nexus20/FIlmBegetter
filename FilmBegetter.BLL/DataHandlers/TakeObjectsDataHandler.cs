using FilmBegetter.BLL.FilterModels;
using FilmBegetter.DAL;

namespace FilmBegetter.BLL.DataHandlers;

public class TakeObjectsDataHandler<TEntity, TFilterModel> : DataHandler<TEntity, TFilterModel> where TEntity : class where TFilterModel : BaseFilterModel {

    public override void AddExpression(Expressions<TEntity> expressions, TFilterModel filterModel) {

        if (filterModel.TakeCount > 0) {
            expressions.TakeCount = filterModel.TakeCount;
        }

        base.AddExpression(expressions, filterModel);
    }
}