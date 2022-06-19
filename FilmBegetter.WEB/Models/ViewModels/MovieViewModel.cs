namespace FilmBegetter.WEB.Models.ViewModels;

public class MovieViewModel : BaseViewModel {

    public string Title { get; set; }

    public string Description { get; set; }

    public string Country { get; set; }

    public string Director { get; set; }

    public DateTime PublicationDate { get; set; }

    public ICollection<GenreViewModel> Genres { get; set; }

    public ICollection<MovieCollectionViewModel> MovieCollections { get; set; }

    public ICollection<RatingViewModel> Ratings { get; set; }

    public ICollection<CommentViewModel> Comments { get; set; }

    public string ImagePath { get; set; }

    public double CommonRating => Ratings.Any() ? Math.Round(Ratings.Average(r => r.RatingValue), 2) : 0;
}