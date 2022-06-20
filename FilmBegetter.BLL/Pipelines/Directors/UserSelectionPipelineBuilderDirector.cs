using FilmBegetter.BLL.DataHandlers;
using FilmBegetter.BLL.DataHandlers.MovieDataHandlers;
using FilmBegetter.BLL.DataHandlers.UserDataHandlers;
using FilmBegetter.BLL.FilterModels;
using FilmBegetter.BLL.Pipelines.Builders;
using FilmBegetter.DAL.Entities;

namespace FilmBegetter.BLL.Pipelines.Directors; 

public class UserSelectionPipelineBuilderDirector  : IPipelineBuilderDirector<User, UserFilterModel> {

    private readonly IPipelineBuilder<User, UserFilterModel> _selectionPipelineBuilder;

    public UserSelectionPipelineBuilderDirector(IPipelineBuilder<User, UserFilterModel> selectionPipelineBuilder) {
        _selectionPipelineBuilder = selectionPipelineBuilder;
    }

    public IDataHandler<User, UserFilterModel> Construct() {

        _selectionPipelineBuilder.SetFirstChainPart<UserEmailFilterDataHandler>()
            // .SetNextChainPart<CarModelSearchDataHandler>()
            // .SetNextChainPart<CarOrderDataHandler>()
            .SetNextChainPart<SkipObjectsDataHandler<User, UserFilterModel>>()
            .SetNextChainPart<TakeObjectsDataHandler<User, UserFilterModel>>();

        return _selectionPipelineBuilder.GetPipeline();
    }
}