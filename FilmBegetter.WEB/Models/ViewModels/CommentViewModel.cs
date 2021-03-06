namespace FilmBegetter.WEB.Models.ViewModels;

public class CommentViewModel : BaseViewModel {

    public string AuthorId { get; set; }

    public UserViewModel Author { get; set; }

    public string MovieId { get; set; }

    public MovieViewModel Movie { get; set; }

    public DateTime CreationDate { get; set; }

    public string Body { get; set; }

    public ICollection<CommentRatingViewModel> CommentRatings { get; set; }
    
    public int Rating => CommentRatings.Any() ? CommentRatings.Sum(x => x.Rating) : 0;
}