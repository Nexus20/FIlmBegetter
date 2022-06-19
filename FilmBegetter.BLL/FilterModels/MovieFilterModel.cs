namespace FilmBegetter.BLL.FilterModels;

public class MovieFilterModel : BaseFilterModel {

    public string Title { get; set; }

    public List<string> Genres { get; set; }
}