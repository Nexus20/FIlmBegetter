namespace FilmBegetter.WEB.Models.ViewModels;

public class CommentRatingViewModel {
    
    public string AuthorId { get; set; }

    public UserViewModel User { get; set; }

    public int Rating { get; set; }
}