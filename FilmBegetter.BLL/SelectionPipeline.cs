using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Pipelines.Directors;
using FilmBegetter.DAL;

namespace FilmBegetter.BLL;

public class SelectionPipeline<TEntity, TFilterModel> where TEntity : class where TFilterModel : BaseFilterModel {

    private readonly TFilterModel _filterModel;

    private readonly IPipelineBuilderDirector<TEntity, TFilterModel> _builderDirector;

    public SelectionPipeline(TFilterModel filterModel, IPipelineBuilderDirector<TEntity, TFilterModel> builderDirector) {
        _filterModel = filterModel;
        _builderDirector = builderDirector;
    }

    public Expressions<TEntity> Process() {

        var expressions = new Expressions<TEntity>();

        _builderDirector.Construct().AddExpression(expressions, _filterModel);

        return expressions;
    }
}