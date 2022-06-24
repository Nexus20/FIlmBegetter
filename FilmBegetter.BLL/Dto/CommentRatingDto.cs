namespace FilmBegetter.BLL.Dto;

public class CommentRatingDto {
    
    public string AuthorId { get; set; }

    public UserDto User { get; set; }

    public int Rating { get; set; }
}