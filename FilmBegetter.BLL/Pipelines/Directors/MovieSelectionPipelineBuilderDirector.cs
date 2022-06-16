using FilmBegetter.BLL.DataHandlers;
using FilmBegetter.BLL.DataHandlers.MovieDataHandlers;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Pipelines.Builders;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.Pipelines.Directors; 

public class MovieSelectionPipelineBuilderDirector  : IPipelineBuilderDirector<Movie, MovieFilterModel> {

    private readonly IPipelineBuilder<Movie, MovieFilterModel> _selectionPipelineBuilder;

    public MovieSelectionPipelineBuilderDirector(IPipelineBuilder<Movie, MovieFilterModel> selectionPipelineBuilder) {
        _selectionPipelineBuilder = selectionPipelineBuilder;
    }

    public IDataHandler<Movie, MovieFilterModel> Construct() {

        _selectionPipelineBuilder.SetFirstChainPart<MovieTitleFilterDataHandler>()
            // .SetNextChainPart<CarModelSearchDataHandler>()
            // .SetNextChainPart<CarOrderDataHandler>()
            .SetNextChainPart<SkipObjectsDataHandler<Movie, MovieFilterModel>>()
            .SetNextChainPart<TakeObjectsDataHandler<Movie, MovieFilterModel>>();

        return _selectionPipelineBuilder.GetPipeline();
    }
}