namespace FilmBegetter.BLL.Dto;

public class MovieCollectionDto : BaseDto {

    public string Name { get; set; }

    public string AuthorId { get; set; }

    public UserDto Author { get; set; }

    public ICollection<MovieDto> Movies { get; set; }
}