namespace FilmBegetter.WEB.Models.ViewModels;

public class RatingViewModel : BaseViewModel {

    public string MovieId { get; set; }

    public MovieViewModel Movie { get; set; }

    public string UserId { get; set; }

    public UserViewModel User { get; set; }

    public double RatingValue { get; set; }
}