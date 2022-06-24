namespace FilmBegetter.DAL.Entities;

public class CommentRatingUser {

    public string CommentId { get; set; }

    public Comment Comment { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }

    public int Rating { get; set; }
}