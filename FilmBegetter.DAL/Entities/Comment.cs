namespace FilmBegetter.DAL.Entities;

public class Comment : BaseEntity {

    public string AuthorId { get; set; }

    public virtual User Author { get; set; }

    public string MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public DateTime CreationDate { get; set; }

    public string Body { get; set; }

    public ICollection<CommentRatingUser> CommentRatings { get; set; }
}