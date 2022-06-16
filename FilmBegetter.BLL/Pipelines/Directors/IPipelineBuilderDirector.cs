using FilmBegetter.BLL.DataHandlers;

namespace FilmBegetter.BLL.Pipelines.Directors;

public interface IPipelineBuilderDirector<TEntity, TFilterModel> where TEntity : class {
    IDataHandler<TEntity, TFilterModel> Construct();
}