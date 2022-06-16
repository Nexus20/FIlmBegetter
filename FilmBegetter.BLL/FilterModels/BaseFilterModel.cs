namespace FilmBegetter.BLL.FilterModels; 

public abstract class BaseFilterModel {
    
    public int PageNumber { get; set; }

    public int TakeCount { get; set; }
}