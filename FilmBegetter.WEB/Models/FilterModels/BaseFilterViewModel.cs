namespace FilmBegetter.WEB.Models.FilterModels; 

public abstract class BaseFilterViewModel {
    
    public int? PageNumber { get; set; }

    public int? TakeCount { get; set; }
}