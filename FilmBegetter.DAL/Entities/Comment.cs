namespace FilmBegetter.DAL.Entities;

public enum CommentType {
    Comment,
    Quote,
    Answer,
}

public class Comment : BaseEntity {

    public string AuthorId { get; set; }

    public User Author { get; set; }

    public string MovieId { get; set; }

    public Movie Movie { get; set; }

    public string? ParentCommentId { get; set; }

    public Comment ParentComment { get; set; }

    public ICollection<Comment> Answers { get; set; }
    
    public CommentType Type { get; set; }

    public DateTime CreationDate { get; set; }

    public string Body { get; set; }
}