using FilmBegetter.Domain;

namespace FilmBegetter.BLL.Dto;

public class CommentDto : BaseDto {

    public string AuthorId { get; set; }

    public UserDto Author { get; set; }

    public string MovieId { get; set; }

    public MovieDto Movie { get; set; }

    public string? ParentCommentId { get; set; }

    public CommentDto ParentComment { get; set; }

    public ICollection<CommentDto> Answers { get; set; }
    
    public CommentType Type { get; set; }

    public DateTime CreationDate { get; set; }

    public string Body { get; set; }
}