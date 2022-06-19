namespace FilmBegetter.WEB.Models.ViewModels;

public class GenreViewModel : BaseViewModel {

    public string Name { get; set; }

    public ICollection<MovieViewModel> Movies { get; set; }
}