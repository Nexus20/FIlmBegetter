namespace FilmBegetter.BLL.Dto;

public class GenreDto : BaseDto {

    public string Name { get; set; }

    public ICollection<MovieDto> Movies { get; set; }
}