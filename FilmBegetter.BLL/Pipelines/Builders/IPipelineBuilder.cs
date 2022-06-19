using FilmBegetter.BLL.DataHandlers;

namespace FilmBegetter.BLL.Pipelines.Builders;

public interface IPipelineBuilder<TEntity, TFilterModel> where TEntity : class where TFilterModel : class {

    IPipelineBuilder<TEntity, TFilterModel> SetFirstChainPart<T>() where T : IDataHandler<TEntity, TFilterModel>;

    IPipelineBuilder<TEntity, TFilterModel> SetNextChainPart<T>() where T : IDataHandler<TEntity, TFilterModel>;

    IDataHandler<TEntity, TFilterModel> GetPipeline();
}