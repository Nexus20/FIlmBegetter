using FilmBegetter.Domain;

namespace FilmBegetter.BLL.FilterModels;

public class MovieFilterModel : BaseFilterModel {

    public string Title { get; set; }

    public List<string> Genres { get; set; }
    
    public List<MovieOrderType>? OrderTypes { get; set; }
    
    public int? Year { get; set; }
}