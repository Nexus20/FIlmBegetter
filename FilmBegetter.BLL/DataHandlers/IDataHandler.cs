using FilmBegetter.DAL;

namespace FilmBegetter.BLL.DataHandlers;

public interface IDataHandler<TEntity, TFilterModel> where TEntity : class {

    IDataHandler<TEntity, TFilterModel> SetNext(IDataHandler<TEntity, TFilterModel> nextHandler);

    void AddExpression(Expressions<TEntity> expressions, TFilterModel filterModel);
}