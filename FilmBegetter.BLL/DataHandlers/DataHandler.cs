using FilmBegetter.DAL;

namespace FilmBegetter.BLL.DataHandlers;

public abstract class DataHandler<TEntity, TFilterModel> : IDataHandler<TEntity, TFilterModel> where TEntity : class {

    private IDataHandler<TEntity, TFilterModel> _nextHandler;

    public IDataHandler<TEntity, TFilterModel> SetNext(IDataHandler<TEntity, TFilterModel> nextHandler) {
        _nextHandler = nextHandler;
        return _nextHandler;
    }

    public virtual void AddExpression(Expressions<TEntity> expressions, TFilterModel filterModel) {
        _nextHandler?.AddExpression(expressions, filterModel);
    }
}