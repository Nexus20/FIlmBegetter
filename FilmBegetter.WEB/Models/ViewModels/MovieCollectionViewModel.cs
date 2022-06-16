namespace FilmBegetter.WEB.Models.ViewModels;

public class MovieCollectionViewModel : BaseViewModel {

    public string Name { get; set; }

    public string AuthorId { get; set; }

    public UserViewModel Author { get; set; }

    public ICollection<MovieViewModel> Movies { get; set; }
}