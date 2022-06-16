namespace FilmBegetter.WEB.Models.FilterModels;

public class MovieFilterViewModel : BaseFilterViewModel {
    
    public string? Title { get; set; }

    public List<string>? Genres { get; set; }
}