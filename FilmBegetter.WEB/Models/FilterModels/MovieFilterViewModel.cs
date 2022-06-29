using FilmBegetter.Domain;

namespace FilmBegetter.WEB.Models.FilterModels;

public class MovieFilterViewModel : BaseFilterViewModel {
    
    public string? Title { get; set; }

    public List<string>? Genres { get; set; }
    
    public List<MovieOrderType>? OrderTypes { get; set; }
    
    public int? Year { get; set; }

    public string? Country { get; set; }
    
    public string? Director { get; set; }
}